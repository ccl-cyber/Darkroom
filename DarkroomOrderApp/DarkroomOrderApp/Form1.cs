using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DarkroomOrderApp.Properties;

namespace DarkroomOrderApp
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class Form1 : Form
    {
        private List<OrderItem> orderItems = new List<OrderItem>();
        private List<string> printSizes = new List<string> { "5x7", "6x8.5", "8x10" };
        private List<string> mediaTypes = new List<string> { "Glossy", "Luster" };
        private string currentPrintSize = "8x10";
        private string currentMedia = "Glossy";
        private int currentQuantity = 1;
        private static readonly Random random = new Random();
        private static int orderCounter = 0;
        private ImageList imageList = new ImageList();

        public Form1()
        {
            InitializeComponent();
            LoadSettings();
            InitializeControls();
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadSettings()
        {
            // Settings are now loaded from Settings.Default
        }

        private void InitializeControls()
        {
            listBoxSizes.DataSource = printSizes;
            comboBoxMedia.DataSource = mediaTypes;
            comboBoxMedia.SelectedIndex = 0;
            for (int i = 1; i <= 10; i++)
                comboBoxQuantity.Items.Add(i);
            comboBoxQuantity.SelectedIndex = 0;

            // Initialize ImageList for thumbnails
            imageList.ImageSize = new Size(100, 100);
            listViewThumbnails.LargeImageList = imageList;

            // Set up search TextBox
            txtSearch.KeyPress += TxtSearch_KeyPress;

            // Set up listBoxFiles
            listBoxFiles.KeyDown += ListBoxFiles_KeyDown;
            listBoxFiles.SelectedIndexChanged += ListBoxFiles_SelectedIndexChanged;

            // Set up listViewThumbnails
            listViewThumbnails.SelectedIndexChanged += ListViewThumbnails_SelectedIndexChanged;

            // Add tooltips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtSearch, "Enter search text and press Enter to search for files.");
            toolTip.SetToolTip(btnSearch, "Click to search for files.");
            toolTip.SetToolTip(listBoxFiles, "List of files matching the search criteria.");
            toolTip.SetToolTip(listViewThumbnails, "Thumbnails of the selected files.");
            toolTip.SetToolTip(listBoxSizes, "Select the print size.");
            toolTip.SetToolTip(comboBoxMedia, "Select the media type.");
            toolTip.SetToolTip(comboBoxQuantity, "Select the quantity.");
            toolTip.SetToolTip(btnAddToOrder, "Add the selected files to the order.");
            toolTip.SetToolTip(btnRemove, "Remove the selected files from the list.");
            toolTip.SetToolTip(btnCreateOrder, "Create an order with the selected items.");
            toolTip.SetToolTip(btnSettings, "Open the settings form.");
        }

        private void TxtSearch_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                PerformSearch();
                txtSearch.SelectAll();
            }
        }

        private void PerformSearch()
        {
            try
            {
                string searchPattern = txtSearch.Text;
                string[] files = Directory.GetFiles(Settings.Default.RootFolder ?? string.Empty, "*.*", SearchOption.AllDirectories)
                    .Where(file => Path.GetFileName(file).Contains(searchPattern, StringComparison.OrdinalIgnoreCase))
                    .ToArray();

                if (files.Length == 0)
                {
                    MessageBox.Show("No matching files found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (string file in files)
                {
                    if (!listBoxFiles.Items.Contains(file))
                    {
                        listBoxFiles.Items.Add(file);
                    }
                }
                UpdateThumbnails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during search: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateThumbnails()
        {
            imageList.Images.Clear();
            listViewThumbnails.Items.Clear();
            foreach (string file in listBoxFiles.Items)
            {
                try
                {
                    using (Image img = Image.FromFile(file))
                    {
                        // Calculate the thumbnail size while maintaining aspect ratio
                        int maxSize = 100;
                        int width = img.Width;
                        int height = img.Height;
                        float ratio = (float)width / height;
                        if (width > height)
                        {
                            width = maxSize;
                            height = (int)(width / ratio);
                        }
                        else
                        {
                            height = maxSize;
                            width = (int)(height * ratio);
                        }
                        Image thumbnail = new Bitmap(maxSize, maxSize);
                        using (Graphics g = Graphics.FromImage(thumbnail))
                        {
                            g.Clear(Color.Transparent);
                            g.DrawImage(img, (maxSize - width) / 2, (maxSize - height) / 2, width, height);
                        }
                        imageList.Images.Add(file, thumbnail);
                        ListViewItem item = new ListViewItem(Path.GetFileName(file))
                        {
                            ImageKey = file
                        };
                        listViewThumbnails.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading image: {ex.Message}");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveSelectedFiles();
        }

        private void ListBoxFiles_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedFiles();
            }
        }

        private void RemoveSelectedFiles()
        {
            var itemsToRemove = listBoxFiles.SelectedItems.Cast<object>().ToList();
            foreach (var item in itemsToRemove)
            {
                listBoxFiles.Items.Remove(item);
                listViewThumbnails.Items.RemoveByKey(item.ToString());
            }
            UpdateThumbnails();
        }

        private void ListBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            SyncSelection(listBoxFiles, listViewThumbnails);
        }

        private void ListViewThumbnails_SelectedIndexChanged(object sender, EventArgs e)
        {
            SyncSelection(listViewThumbnails, listBoxFiles);
        }

        private void SyncSelection(ListBox listBox, ListView listView)
        {
            listView.SelectedItems.Clear();
            foreach (var item in listBox.SelectedItems)
            {
                foreach (ListViewItem listViewItem in listView.Items)
                {
                    if (listViewItem.Text == item.ToString())
                    {
                        listViewItem.Selected = true;
                        listViewItem.EnsureVisible();
                        break;
                    }
                }
            }
        }

        private void SyncSelection(ListView listView, ListBox listBox)
        {
            listBox.ClearSelected();
            foreach (ListViewItem item in listView.SelectedItems)
            {
                for (int i = 0; i < listBox.Items.Count; i++)
                {
                    if (listBox.Items[i].ToString() == item.Text)
                    {
                        listBox.SetSelected(i, true);
                        break;
                    }
                }
            }
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            foreach (var selectedItem in listBoxFiles.SelectedItems)
            {
                string selectedFile = selectedItem.ToString();
                if (File.Exists(selectedFile))
                {
                    AddToOrder(selectedFile);
                }
            }
        }

        private void AddToOrder(string filePath)
        {
            OrderItem newItem = new OrderItem
            {
                FileName = filePath,
                PrintSize = currentPrintSize,
                Media = currentMedia,
                Quantity = currentQuantity
            };
            orderItems.Add(newItem);
            UpdateOrderListBox();
        }

        private void UpdateOrderListBox()
        {
            listBoxOrder.Items.Clear();
            foreach (var item in orderItems)
            {
                listBoxOrder.Items.Add($"{item.Quantity} {item.PrintSize} - {Path.GetFileName(item.FileName)} - {item.Media}");
            }
        }

        private void listBoxSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPrintSize = listBoxSizes.SelectedItem?.ToString() ?? string.Empty;
        }

        private void comboBoxMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMedia = comboBoxMedia.SelectedItem?.ToString() ?? string.Empty;
        }

        private void comboBoxQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentQuantity = (int)(comboBoxQuantity.SelectedItem ?? 1);
        }

        private string GenerateUniqueOrderName()
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = random.Next(10).ToString();
            for (int i = 1; i < 6; i++)
            {
                result += chars[random.Next(chars.Length)];
            }
            return $"{result}_{orderCounter++}";
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string orderFileName = $"{GenerateUniqueOrderName()}.txt";
                string orderFilePath = Path.Combine(Settings.Default.OrderSaveLocation ?? string.Empty, orderFileName);
                using (StreamWriter ordWriter = new StreamWriter(orderFilePath, false, Encoding.UTF8))
                {
                    foreach (OrderItem item in orderItems)
                    {
                        ordWriter.WriteLine($"Qty={item.Quantity}");
                        ordWriter.WriteLine($"Size={item.PrintSize}");
                        ordWriter.WriteLine($"Media={item.Media}");
                        ordWriter.WriteLine($"Filepath={item.FileName}");
                        ordWriter.WriteLine();
                    }
                }
                MessageBox.Show($"Order file created successfully at:\n{orderFilePath}");
                orderItems.Clear();
                listBoxOrder.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating order file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSettings();
                }
            }
        }

        public class OrderItem
        {
            public string FileName { get; set; } = string.Empty;
            public string PrintSize { get; set; } = string.Empty;
            public string Media { get; set; } = string.Empty;
            public int Quantity { get; set; }
        }
    }
}
