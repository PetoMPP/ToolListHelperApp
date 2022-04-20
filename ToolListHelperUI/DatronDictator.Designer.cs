namespace ToolListHelperUI
{
    partial class DatronDictator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.descriptionPanel = new System.Windows.Forms.Panel();
            this.moduleDescriptionLabel = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.dictonaryDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridButtonsPanel = new System.Windows.Forms.Panel();
            this.deleteSelectedButtonPanel = new System.Windows.Forms.Panel();
            this.deleteSelectedButton = new System.Windows.Forms.Button();
            this.saveChangesButtonPanel = new System.Windows.Forms.Panel();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.addNewEntryButtonPanel = new System.Windows.Forms.Panel();
            this.addNewEntryButton = new System.Windows.Forms.Button();
            this.tdmNamePanel = new System.Windows.Forms.Panel();
            this.tdmNameTextBoxPanel = new System.Windows.Forms.Panel();
            this.tdmNameTextBox = new System.Windows.Forms.TextBox();
            this.tdmNameLabel = new System.Windows.Forms.Label();
            this.programNamePanel = new System.Windows.Forms.Panel();
            this.programNameTextBoxPanel = new System.Windows.Forms.Panel();
            this.programNameTextBox = new System.Windows.Forms.TextBox();
            this.programNameLabel = new System.Windows.Forms.Label();
            this.addNewEntryLabel = new System.Windows.Forms.Label();
            this.importDictonaryButtonPanel = new System.Windows.Forms.Panel();
            this.importDictonaryButton = new System.Windows.Forms.Button();
            this.reloadDictonaryButtonPanel = new System.Windows.Forms.Panel();
            this.reloadDictonaryButton = new System.Windows.Forms.Button();
            this.descriptionPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dictonaryDataGridView)).BeginInit();
            this.dataGridButtonsPanel.SuspendLayout();
            this.deleteSelectedButtonPanel.SuspendLayout();
            this.saveChangesButtonPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.addNewEntryButtonPanel.SuspendLayout();
            this.tdmNamePanel.SuspendLayout();
            this.tdmNameTextBoxPanel.SuspendLayout();
            this.programNamePanel.SuspendLayout();
            this.programNameTextBoxPanel.SuspendLayout();
            this.importDictonaryButtonPanel.SuspendLayout();
            this.reloadDictonaryButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // descriptionPanel
            // 
            this.descriptionPanel.AutoScroll = true;
            this.descriptionPanel.Controls.Add(this.moduleDescriptionLabel);
            this.descriptionPanel.Location = new System.Drawing.Point(0, 0);
            this.descriptionPanel.Name = "descriptionPanel";
            this.descriptionPanel.Size = new System.Drawing.Size(900, 80);
            this.descriptionPanel.TabIndex = 6;
            // 
            // moduleDescriptionLabel
            // 
            this.moduleDescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.moduleDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduleDescriptionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moduleDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.moduleDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.moduleDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.moduleDescriptionLabel.MinimumSize = new System.Drawing.Size(20, 0);
            this.moduleDescriptionLabel.Name = "moduleDescriptionLabel";
            this.moduleDescriptionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.moduleDescriptionLabel.Size = new System.Drawing.Size(900, 80);
            this.moduleDescriptionLabel.TabIndex = 1;
            this.moduleDescriptionLabel.Text = "Moduł do manipulacji słownikiem do automatycznej zamiany numerów katalogowych nar" +
    "zędzi w programach z Fusion";
            this.moduleDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.dictonaryDataGridView);
            this.leftPanel.Controls.Add(this.dataGridButtonsPanel);
            this.leftPanel.Location = new System.Drawing.Point(0, 80);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(450, 700);
            this.leftPanel.TabIndex = 7;
            // 
            // dictonaryDataGridView
            // 
            this.dictonaryDataGridView.AllowUserToAddRows = false;
            this.dictonaryDataGridView.AllowUserToDeleteRows = false;
            this.dictonaryDataGridView.AllowUserToOrderColumns = true;
            this.dictonaryDataGridView.AllowUserToResizeRows = false;
            this.dictonaryDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dictonaryDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dictonaryDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dictonaryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dictonaryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dictonaryDataGridView.EnableHeadersVisualStyles = false;
            this.dictonaryDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.dictonaryDataGridView.Location = new System.Drawing.Point(0, 50);
            this.dictonaryDataGridView.Name = "dictonaryDataGridView";
            this.dictonaryDataGridView.ReadOnly = true;
            this.dictonaryDataGridView.RowHeadersVisible = false;
            this.dictonaryDataGridView.RowTemplate.Height = 25;
            this.dictonaryDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dictonaryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dictonaryDataGridView.Size = new System.Drawing.Size(450, 650);
            this.dictonaryDataGridView.TabIndex = 2;
            this.dictonaryDataGridView.SelectionChanged += new System.EventHandler(this.DictonaryDataGridView_SelectionChanged);
            // 
            // dataGridButtonsPanel
            // 
            this.dataGridButtonsPanel.Controls.Add(this.deleteSelectedButtonPanel);
            this.dataGridButtonsPanel.Controls.Add(this.saveChangesButtonPanel);
            this.dataGridButtonsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.dataGridButtonsPanel.Name = "dataGridButtonsPanel";
            this.dataGridButtonsPanel.Size = new System.Drawing.Size(450, 50);
            this.dataGridButtonsPanel.TabIndex = 0;
            // 
            // deleteSelectedButtonPanel
            // 
            this.deleteSelectedButtonPanel.Controls.Add(this.deleteSelectedButton);
            this.deleteSelectedButtonPanel.Location = new System.Drawing.Point(225, 0);
            this.deleteSelectedButtonPanel.Name = "deleteSelectedButtonPanel";
            this.deleteSelectedButtonPanel.Padding = new System.Windows.Forms.Padding(11);
            this.deleteSelectedButtonPanel.Size = new System.Drawing.Size(225, 50);
            this.deleteSelectedButtonPanel.TabIndex = 6;
            // 
            // deleteSelectedButton
            // 
            this.deleteSelectedButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteSelectedButton.Enabled = false;
            this.deleteSelectedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSelectedButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteSelectedButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteSelectedButton.Location = new System.Drawing.Point(11, 11);
            this.deleteSelectedButton.Name = "deleteSelectedButton";
            this.deleteSelectedButton.Size = new System.Drawing.Size(203, 28);
            this.deleteSelectedButton.TabIndex = 2;
            this.deleteSelectedButton.Tag = "ColorfulForeRed";
            this.deleteSelectedButton.Text = "Usuń zaznaczenie";
            this.deleteSelectedButton.UseVisualStyleBackColor = true;
            this.deleteSelectedButton.Click += new System.EventHandler(this.DeleteSelectedButton_Click);
            // 
            // saveChangesButtonPanel
            // 
            this.saveChangesButtonPanel.Controls.Add(this.saveChangesButton);
            this.saveChangesButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.saveChangesButtonPanel.Name = "saveChangesButtonPanel";
            this.saveChangesButtonPanel.Padding = new System.Windows.Forms.Padding(11);
            this.saveChangesButtonPanel.Size = new System.Drawing.Size(225, 50);
            this.saveChangesButtonPanel.TabIndex = 5;
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveChangesButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveChangesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.saveChangesButton.Location = new System.Drawing.Point(11, 11);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(203, 28);
            this.saveChangesButton.TabIndex = 2;
            this.saveChangesButton.Tag = "ColorfulForeGreen";
            this.saveChangesButton.Text = "Zapisz Zmiany";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.addNewEntryButtonPanel);
            this.rightPanel.Controls.Add(this.tdmNamePanel);
            this.rightPanel.Controls.Add(this.programNamePanel);
            this.rightPanel.Controls.Add(this.addNewEntryLabel);
            this.rightPanel.Controls.Add(this.importDictonaryButtonPanel);
            this.rightPanel.Controls.Add(this.reloadDictonaryButtonPanel);
            this.rightPanel.Location = new System.Drawing.Point(450, 80);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(450, 700);
            this.rightPanel.TabIndex = 8;
            // 
            // addNewEntryButtonPanel
            // 
            this.addNewEntryButtonPanel.Controls.Add(this.addNewEntryButton);
            this.addNewEntryButtonPanel.Location = new System.Drawing.Point(0, 140);
            this.addNewEntryButtonPanel.Name = "addNewEntryButtonPanel";
            this.addNewEntryButtonPanel.Padding = new System.Windows.Forms.Padding(36, 11, 36, 11);
            this.addNewEntryButtonPanel.Size = new System.Drawing.Size(450, 50);
            this.addNewEntryButtonPanel.TabIndex = 12;
            // 
            // addNewEntryButton
            // 
            this.addNewEntryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addNewEntryButton.Enabled = false;
            this.addNewEntryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNewEntryButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addNewEntryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.addNewEntryButton.Location = new System.Drawing.Point(36, 11);
            this.addNewEntryButton.Name = "addNewEntryButton";
            this.addNewEntryButton.Size = new System.Drawing.Size(378, 28);
            this.addNewEntryButton.TabIndex = 2;
            this.addNewEntryButton.Text = "Dodaj nowy wpis do słownika";
            this.addNewEntryButton.UseVisualStyleBackColor = true;
            this.addNewEntryButton.Click += new System.EventHandler(this.AddNewEntryButton_Click);
            // 
            // tdmNamePanel
            // 
            this.tdmNamePanel.Controls.Add(this.tdmNameTextBoxPanel);
            this.tdmNamePanel.Controls.Add(this.tdmNameLabel);
            this.tdmNamePanel.Location = new System.Drawing.Point(225, 80);
            this.tdmNamePanel.Name = "tdmNamePanel";
            this.tdmNamePanel.Size = new System.Drawing.Size(225, 60);
            this.tdmNamePanel.TabIndex = 11;
            // 
            // tdmNameTextBoxPanel
            // 
            this.tdmNameTextBoxPanel.Controls.Add(this.tdmNameTextBox);
            this.tdmNameTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tdmNameTextBoxPanel.Location = new System.Drawing.Point(0, 25);
            this.tdmNameTextBoxPanel.Name = "tdmNameTextBoxPanel";
            this.tdmNameTextBoxPanel.Padding = new System.Windows.Forms.Padding(5);
            this.tdmNameTextBoxPanel.Size = new System.Drawing.Size(225, 35);
            this.tdmNameTextBoxPanel.TabIndex = 11;
            // 
            // tdmNameTextBox
            // 
            this.tdmNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tdmNameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tdmNameTextBox.Location = new System.Drawing.Point(5, 5);
            this.tdmNameTextBox.Name = "tdmNameTextBox";
            this.tdmNameTextBox.Size = new System.Drawing.Size(215, 25);
            this.tdmNameTextBox.TabIndex = 4;
            this.tdmNameTextBox.TextChanged += new System.EventHandler(this.NewEntryTextBox_TextChanged);
            // 
            // tdmNameLabel
            // 
            this.tdmNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tdmNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tdmNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.tdmNameLabel.Location = new System.Drawing.Point(0, 0);
            this.tdmNameLabel.Name = "tdmNameLabel";
            this.tdmNameLabel.Size = new System.Drawing.Size(225, 25);
            this.tdmNameLabel.TabIndex = 10;
            this.tdmNameLabel.Text = "Nazwa w TDM";
            this.tdmNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // programNamePanel
            // 
            this.programNamePanel.Controls.Add(this.programNameTextBoxPanel);
            this.programNamePanel.Controls.Add(this.programNameLabel);
            this.programNamePanel.Location = new System.Drawing.Point(0, 80);
            this.programNamePanel.Name = "programNamePanel";
            this.programNamePanel.Size = new System.Drawing.Size(225, 60);
            this.programNamePanel.TabIndex = 10;
            // 
            // programNameTextBoxPanel
            // 
            this.programNameTextBoxPanel.Controls.Add(this.programNameTextBox);
            this.programNameTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.programNameTextBoxPanel.Location = new System.Drawing.Point(0, 25);
            this.programNameTextBoxPanel.Name = "programNameTextBoxPanel";
            this.programNameTextBoxPanel.Padding = new System.Windows.Forms.Padding(5);
            this.programNameTextBoxPanel.Size = new System.Drawing.Size(225, 35);
            this.programNameTextBoxPanel.TabIndex = 11;
            // 
            // programNameTextBox
            // 
            this.programNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programNameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.programNameTextBox.Location = new System.Drawing.Point(5, 5);
            this.programNameTextBox.Name = "programNameTextBox";
            this.programNameTextBox.Size = new System.Drawing.Size(215, 25);
            this.programNameTextBox.TabIndex = 4;
            this.programNameTextBox.TextChanged += new System.EventHandler(this.NewEntryTextBox_TextChanged);
            // 
            // programNameLabel
            // 
            this.programNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.programNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.programNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.programNameLabel.Location = new System.Drawing.Point(0, 0);
            this.programNameLabel.Name = "programNameLabel";
            this.programNameLabel.Size = new System.Drawing.Size(225, 25);
            this.programNameLabel.TabIndex = 10;
            this.programNameLabel.Text = "Nazwa w pliku Fusion";
            this.programNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addNewEntryLabel
            // 
            this.addNewEntryLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addNewEntryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.addNewEntryLabel.Location = new System.Drawing.Point(0, 50);
            this.addNewEntryLabel.Name = "addNewEntryLabel";
            this.addNewEntryLabel.Size = new System.Drawing.Size(450, 30);
            this.addNewEntryLabel.TabIndex = 9;
            this.addNewEntryLabel.Text = "Dodaj nowy wpis do słownika:";
            this.addNewEntryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // importDictonaryButtonPanel
            // 
            this.importDictonaryButtonPanel.Controls.Add(this.importDictonaryButton);
            this.importDictonaryButtonPanel.Location = new System.Drawing.Point(225, 0);
            this.importDictonaryButtonPanel.Name = "importDictonaryButtonPanel";
            this.importDictonaryButtonPanel.Padding = new System.Windows.Forms.Padding(11);
            this.importDictonaryButtonPanel.Size = new System.Drawing.Size(225, 50);
            this.importDictonaryButtonPanel.TabIndex = 8;
            // 
            // importDictonaryButton
            // 
            this.importDictonaryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importDictonaryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importDictonaryButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.importDictonaryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.importDictonaryButton.Location = new System.Drawing.Point(11, 11);
            this.importDictonaryButton.Name = "importDictonaryButton";
            this.importDictonaryButton.Size = new System.Drawing.Size(203, 28);
            this.importDictonaryButton.TabIndex = 2;
            this.importDictonaryButton.Tag = "ColorfulForeBlue";
            this.importDictonaryButton.Text = "Importuj słownik z pliku *.txt";
            this.importDictonaryButton.UseVisualStyleBackColor = true;
            this.importDictonaryButton.Click += new System.EventHandler(this.ImportDictonaryButton_Click);
            // 
            // reloadDictonaryButtonPanel
            // 
            this.reloadDictonaryButtonPanel.Controls.Add(this.reloadDictonaryButton);
            this.reloadDictonaryButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.reloadDictonaryButtonPanel.Name = "reloadDictonaryButtonPanel";
            this.reloadDictonaryButtonPanel.Padding = new System.Windows.Forms.Padding(11);
            this.reloadDictonaryButtonPanel.Size = new System.Drawing.Size(225, 50);
            this.reloadDictonaryButtonPanel.TabIndex = 7;
            // 
            // reloadDictonaryButton
            // 
            this.reloadDictonaryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reloadDictonaryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reloadDictonaryButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reloadDictonaryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.reloadDictonaryButton.Location = new System.Drawing.Point(11, 11);
            this.reloadDictonaryButton.Name = "reloadDictonaryButton";
            this.reloadDictonaryButton.Size = new System.Drawing.Size(203, 28);
            this.reloadDictonaryButton.TabIndex = 2;
            this.reloadDictonaryButton.Tag = "ColorfulForePurple";
            this.reloadDictonaryButton.Text = "Ponownie załaduj słownik";
            this.reloadDictonaryButton.UseVisualStyleBackColor = true;
            this.reloadDictonaryButton.Click += new System.EventHandler(this.ReloadDictonaryButton_Click);
            // 
            // DatronDictator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 780);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.descriptionPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(10, 0);
            this.Name = "DatronDictator";
            this.Text = "DatronDictator";
            this.Resize += new System.EventHandler(this.DatronDictator_Resize);
            this.descriptionPanel.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dictonaryDataGridView)).EndInit();
            this.dataGridButtonsPanel.ResumeLayout(false);
            this.deleteSelectedButtonPanel.ResumeLayout(false);
            this.saveChangesButtonPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.addNewEntryButtonPanel.ResumeLayout(false);
            this.tdmNamePanel.ResumeLayout(false);
            this.tdmNameTextBoxPanel.ResumeLayout(false);
            this.tdmNameTextBoxPanel.PerformLayout();
            this.programNamePanel.ResumeLayout(false);
            this.programNameTextBoxPanel.ResumeLayout(false);
            this.programNameTextBoxPanel.PerformLayout();
            this.importDictonaryButtonPanel.ResumeLayout(false);
            this.reloadDictonaryButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel descriptionPanel;
        private Label moduleDescriptionLabel;
        private Panel leftPanel;
        private Panel dataGridButtonsPanel;
        private Panel rightPanel;
        private Panel deleteSelectedButtonPanel;
        private Button deleteSelectedButton;
        private Panel saveChangesButtonPanel;
        private Button saveChangesButton;
        private Panel importDictonaryButtonPanel;
        private Button importDictonaryButton;
        private Panel reloadDictonaryButtonPanel;
        private Button reloadDictonaryButton;
        private DataGridView dictonaryDataGridView;
        private Panel programNamePanel;
        private Label programNameLabel;
        private Label addNewEntryLabel;
        private Panel addNewEntryButtonPanel;
        private Button addNewEntryButton;
        private Panel tdmNamePanel;
        private Panel tdmNameTextBoxPanel;
        private TextBox tdmNameTextBox;
        private Label tdmNameLabel;
        private Panel programNameTextBoxPanel;
        private TextBox programNameTextBox;
    }
}