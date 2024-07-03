namespace DarkroomOrderApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtSearch = new TextBox();
            btnSearch = new Button();
            listBoxFiles = new ListBox();
            listViewThumbnails = new ListView();
            listBoxSizes = new ListBox();
            comboBoxMedia = new ComboBox();
            comboBoxQuantity = new ComboBox();
            listBoxOrder = new ListBox();
            btnCreateOrder = new Button();
            btnSettings = new Button();
            btnRemove = new Button();
            btnAddToOrder = new Button();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(14, 14);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(699, 23);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.Location = new Point(721, 12);
            btnSearch.Margin = new Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(88, 27);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // listBoxFiles
            // 
            listBoxFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.ItemHeight = 15;
            listBoxFiles.Location = new Point(14, 44);
            listBoxFiles.Margin = new Padding(4, 3, 4, 3);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.SelectionMode = SelectionMode.MultiExtended;
            listBoxFiles.Size = new Size(794, 199);
            listBoxFiles.TabIndex = 2;
            // 
            // listViewThumbnails
            // 
            listViewThumbnails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewThumbnails.Location = new Point(14, 281);
            listViewThumbnails.Margin = new Padding(4, 3, 4, 3);
            listViewThumbnails.Name = "listViewThumbnails";
            listViewThumbnails.Size = new Size(794, 206);
            listViewThumbnails.TabIndex = 3;
            listViewThumbnails.UseCompatibleStateImageBehavior = false;
            // 
            // listBoxSizes
            // 
            listBoxSizes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxSizes.FormattingEnabled = true;
            listBoxSizes.ItemHeight = 15;
            listBoxSizes.Location = new Point(14, 495);
            listBoxSizes.Margin = new Padding(4, 3, 4, 3);
            listBoxSizes.Name = "listBoxSizes";
            listBoxSizes.Size = new Size(139, 109);
            listBoxSizes.TabIndex = 4;
            listBoxSizes.SelectedIndexChanged += listBoxSizes_SelectedIndexChanged;
            // 
            // comboBoxMedia
            // 
            comboBoxMedia.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxMedia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMedia.FormattingEnabled = true;
            comboBoxMedia.Location = new Point(161, 497);
            comboBoxMedia.Margin = new Padding(4, 3, 4, 3);
            comboBoxMedia.Name = "comboBoxMedia";
            comboBoxMedia.Size = new Size(140, 23);
            comboBoxMedia.TabIndex = 5;
            comboBoxMedia.SelectedIndexChanged += comboBoxMedia_SelectedIndexChanged;
            // 
            // comboBoxQuantity
            // 
            comboBoxQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxQuantity.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxQuantity.FormattingEnabled = true;
            comboBoxQuantity.Location = new Point(310, 497);
            comboBoxQuantity.Margin = new Padding(4, 3, 4, 3);
            comboBoxQuantity.Name = "comboBoxQuantity";
            comboBoxQuantity.Size = new Size(69, 23);
            comboBoxQuantity.TabIndex = 6;
            comboBoxQuantity.SelectedIndexChanged += comboBoxQuantity_SelectedIndexChanged;
            // 
            // listBoxOrder
            // 
            listBoxOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            listBoxOrder.FormattingEnabled = true;
            listBoxOrder.ItemHeight = 15;
            listBoxOrder.Location = new Point(817, 240);
            listBoxOrder.Margin = new Padding(4, 3, 4, 3);
            listBoxOrder.Name = "listBoxOrder";
            listBoxOrder.Size = new Size(233, 214);
            listBoxOrder.TabIndex = 7;
            // 
            // btnCreateOrder
            // 
            btnCreateOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCreateOrder.Location = new Point(817, 460);
            btnCreateOrder.Margin = new Padding(4, 3, 4, 3);
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.Size = new Size(233, 27);
            btnCreateOrder.TabIndex = 8;
            btnCreateOrder.Text = "Create Order";
            btnCreateOrder.UseVisualStyleBackColor = true;
            btnCreateOrder.Click += btnCreateOrder_Click;
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings.Location = new Point(961, 12);
            btnSettings.Margin = new Padding(4, 3, 4, 3);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(88, 27);
            btnSettings.TabIndex = 9;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(14, 245);
            btnRemove.Margin = new Padding(4, 3, 4, 3);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(88, 27);
            btnRemove.TabIndex = 10;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAddToOrder
            // 
            btnAddToOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddToOrder.Location = new Point(721, 245);
            btnAddToOrder.Margin = new Padding(4, 3, 4, 3);
            btnAddToOrder.Name = "btnAddToOrder";
            btnAddToOrder.Size = new Size(88, 27);
            btnAddToOrder.TabIndex = 11;
            btnAddToOrder.Text = "Add to Order";
            btnAddToOrder.UseVisualStyleBackColor = true;
            btnAddToOrder.Click += btnAddToOrder_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 613);
            Controls.Add(btnAddToOrder);
            Controls.Add(btnRemove);
            Controls.Add(btnSettings);
            Controls.Add(btnCreateOrder);
            Controls.Add(listBoxOrder);
            Controls.Add(comboBoxQuantity);
            Controls.Add(comboBoxMedia);
            Controls.Add(listBoxSizes);
            Controls.Add(listViewThumbnails);
            Controls.Add(listBoxFiles);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Darkroom Order App";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.ListView listViewThumbnails;
        private System.Windows.Forms.ListBox listBoxSizes;
        private System.Windows.Forms.ComboBox comboBoxMedia;
        private System.Windows.Forms.ComboBox comboBoxQuantity;
        private System.Windows.Forms.ListBox listBoxOrder;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddToOrder;
    }
}