using System;
using System.IO;
using System.Windows.Forms;
using DarkroomOrderApp.Properties;

namespace DarkroomOrderApp
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            txtRootFolder.Text = Settings.Default.RootFolder;
            txtCanvasFolder.Text = Settings.Default.CanvasFolder;
            txtUSBFolder.Text = Settings.Default.USBFolder;
            txtOrderSaveLocation.Text = Settings.Default.OrderSaveLocation;
            txtWalletFolder.Text = Settings.Default.WalletFolder;
        }

        private void BrowseFolder(TextBox textBox)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = folderBrowser.SelectedPath;
                }
            }
        }

        private void btnBrowseRoot_Click(object? sender, EventArgs e)
        {
            BrowseFolder(txtRootFolder);
        }

        private void btnBrowseCanvas_Click(object? sender, EventArgs e)
        {
            BrowseFolder(txtCanvasFolder);
        }

        private void btnBrowseUSB_Click(object? sender, EventArgs e)
        {
            BrowseFolder(txtUSBFolder);
        }

        private void btnBrowseOrderSave_Click(object? sender, EventArgs e)
        {
            BrowseFolder(txtOrderSaveLocation);
        }

        private void btnBrowseWallet_Click(object? sender, EventArgs e)
        {
            BrowseFolder(txtWalletFolder);
        }

        private void btnPhotographerData_Click(object? sender, EventArgs e)
        {
            OpenEmbeddedCsvFile("PhotographerData.csv");
        }

        private void btnCropCutData_Click(object? sender, EventArgs e)
        {
            OpenEmbeddedCsvFile("CropCutData.csv");
        }

        private void OpenEmbeddedCsvFile(string fileName)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), fileName);
            string fullResourceName = $"{GetType().Namespace}.Resources.{fileName}";

            using (Stream? resource = GetType().Assembly.GetManifestResourceStream(fullResourceName))
            {
                if (resource != null)
                {
                    using (FileStream file = File.Create(tempPath))
                    {
                        resource.CopyTo(file);
                    }

                    try
                    {
                        var psi = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = tempPath,
                            UseShellExecute = true
                        };
                        System.Diagnostics.Process.Start(psi);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string availableResources = string.Join(", ", GetType().Assembly.GetManifestResourceNames());
                    MessageBox.Show($"Could not find the embedded resource: {fullResourceName}\n\nAvailable resources: {availableResources}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            Settings.Default.RootFolder = txtRootFolder.Text;
            Settings.Default.CanvasFolder = txtCanvasFolder.Text;
            Settings.Default.USBFolder = txtUSBFolder.Text;
            Settings.Default.OrderSaveLocation = txtOrderSaveLocation.Text;
            Settings.Default.WalletFolder = txtWalletFolder.Text;
            Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}