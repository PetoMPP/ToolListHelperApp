namespace ToolListHelperUI.ToolListManagerClasses
{
    partial class ToolListManager
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
            this.descriptionPanel = new System.Windows.Forms.Panel();
            this.moduleDescriptionLabel = new System.Windows.Forms.Label();
            this.selectedListPanel = new System.Windows.Forms.Panel();
            this.deleteListButton = new System.Windows.Forms.Button();
            this.saveListButton = new System.Windows.Forms.Button();
            this.loadListButton = new System.Windows.Forms.Button();
            this.listIdPanel = new System.Windows.Forms.Panel();
            this.listIdTextBoxPanel = new System.Windows.Forms.Panel();
            this.listIdTextBox = new System.Windows.Forms.TextBox();
            this.browseListIdPanel = new System.Windows.Forms.Panel();
            this.browselistIdButton = new System.Windows.Forms.Button();
            this.selectedListLabel = new System.Windows.Forms.Label();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.documentsLabel = new System.Windows.Forms.Label();
            this.fileManagementLabel = new System.Windows.Forms.Label();
            this.toolListLabel = new System.Windows.Forms.Label();
            this.basicDataLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.descriptionPanel.SuspendLayout();
            this.selectedListPanel.SuspendLayout();
            this.listIdPanel.SuspendLayout();
            this.listIdTextBoxPanel.SuspendLayout();
            this.browseListIdPanel.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
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
            this.moduleDescriptionLabel.BackColor = System.Drawing.Color.White;
            this.moduleDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduleDescriptionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moduleDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.moduleDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.moduleDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.moduleDescriptionLabel.Name = "moduleDescriptionLabel";
            this.moduleDescriptionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.moduleDescriptionLabel.Size = new System.Drawing.Size(900, 80);
            this.moduleDescriptionLabel.TabIndex = 1;
            this.moduleDescriptionLabel.Text = "Program do przeglądania, edycji i zarządzania plikami programów w TDM. Pracę nale" +
    "ży rozpocząć od wybrania listy.";
            this.moduleDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectedListPanel
            // 
            this.selectedListPanel.Controls.Add(this.deleteListButton);
            this.selectedListPanel.Controls.Add(this.saveListButton);
            this.selectedListPanel.Controls.Add(this.loadListButton);
            this.selectedListPanel.Controls.Add(this.listIdPanel);
            this.selectedListPanel.Controls.Add(this.selectedListLabel);
            this.selectedListPanel.Location = new System.Drawing.Point(0, 80);
            this.selectedListPanel.Name = "selectedListPanel";
            this.selectedListPanel.Size = new System.Drawing.Size(900, 47);
            this.selectedListPanel.TabIndex = 7;
            // 
            // deleteListButton
            // 
            this.deleteListButton.BackColor = System.Drawing.Color.White;
            this.deleteListButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.deleteListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteListButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteListButton.ForeColor = System.Drawing.Color.DarkRed;
            this.deleteListButton.Location = new System.Drawing.Point(793, 10);
            this.deleteListButton.Margin = new System.Windows.Forms.Padding(10);
            this.deleteListButton.Name = "deleteListButton";
            this.deleteListButton.Size = new System.Drawing.Size(96, 27);
            this.deleteListButton.TabIndex = 6;
            this.deleteListButton.Text = "Usuń listę";
            this.deleteListButton.UseVisualStyleBackColor = false;
            // 
            // saveListButton
            // 
            this.saveListButton.BackColor = System.Drawing.Color.White;
            this.saveListButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.saveListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveListButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveListButton.ForeColor = System.Drawing.Color.Green;
            this.saveListButton.Location = new System.Drawing.Point(684, 10);
            this.saveListButton.Margin = new System.Windows.Forms.Padding(10);
            this.saveListButton.Name = "saveListButton";
            this.saveListButton.Size = new System.Drawing.Size(96, 27);
            this.saveListButton.TabIndex = 6;
            this.saveListButton.Text = "Zapisz zmiany";
            this.saveListButton.UseVisualStyleBackColor = false;
            // 
            // loadListButton
            // 
            this.loadListButton.BackColor = System.Drawing.Color.White;
            this.loadListButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.loadListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadListButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadListButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.loadListButton.Location = new System.Drawing.Point(575, 10);
            this.loadListButton.Margin = new System.Windows.Forms.Padding(10);
            this.loadListButton.Name = "loadListButton";
            this.loadListButton.Size = new System.Drawing.Size(96, 27);
            this.loadListButton.TabIndex = 6;
            this.loadListButton.Text = "Załaduj listę";
            this.loadListButton.UseVisualStyleBackColor = false;
            this.loadListButton.Click += new System.EventHandler(this.LoadListButton_Click);
            // 
            // listIdPanel
            // 
            this.listIdPanel.Controls.Add(this.listIdTextBoxPanel);
            this.listIdPanel.Controls.Add(this.browseListIdPanel);
            this.listIdPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.listIdPanel.Location = new System.Drawing.Point(337, 0);
            this.listIdPanel.Name = "listIdPanel";
            this.listIdPanel.Size = new System.Drawing.Size(225, 47);
            this.listIdPanel.TabIndex = 5;
            // 
            // listIdTextBoxPanel
            // 
            this.listIdTextBoxPanel.Controls.Add(this.listIdTextBox);
            this.listIdTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listIdTextBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.listIdTextBoxPanel.Name = "listIdTextBoxPanel";
            this.listIdTextBoxPanel.Padding = new System.Windows.Forms.Padding(11);
            this.listIdTextBoxPanel.Size = new System.Drawing.Size(175, 47);
            this.listIdTextBoxPanel.TabIndex = 1;
            // 
            // listIdTextBox
            // 
            this.listIdTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listIdTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listIdTextBox.Location = new System.Drawing.Point(11, 11);
            this.listIdTextBox.Name = "listIdTextBox";
            this.listIdTextBox.Size = new System.Drawing.Size(153, 25);
            this.listIdTextBox.TabIndex = 3;
            // 
            // browseListIdPanel
            // 
            this.browseListIdPanel.Controls.Add(this.browselistIdButton);
            this.browseListIdPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.browseListIdPanel.Location = new System.Drawing.Point(175, 0);
            this.browseListIdPanel.Name = "browseListIdPanel";
            this.browseListIdPanel.Padding = new System.Windows.Forms.Padding(5);
            this.browseListIdPanel.Size = new System.Drawing.Size(50, 47);
            this.browseListIdPanel.TabIndex = 2;
            // 
            // browselistIdButton
            // 
            this.browselistIdButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browselistIdButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browselistIdButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.browselistIdButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.browselistIdButton.Location = new System.Drawing.Point(5, 5);
            this.browselistIdButton.Margin = new System.Windows.Forms.Padding(0);
            this.browselistIdButton.Name = "browselistIdButton";
            this.browselistIdButton.Size = new System.Drawing.Size(40, 37);
            this.browselistIdButton.TabIndex = 4;
            this.browselistIdButton.Tag = "ProgramId";
            this.browselistIdButton.Text = "▼";
            this.browselistIdButton.UseVisualStyleBackColor = false;
            // 
            // selectedListLabel
            // 
            this.selectedListLabel.BackColor = System.Drawing.Color.White;
            this.selectedListLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.selectedListLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectedListLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectedListLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.selectedListLabel.Location = new System.Drawing.Point(0, 0);
            this.selectedListLabel.Name = "selectedListLabel";
            this.selectedListLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.selectedListLabel.Size = new System.Drawing.Size(337, 47);
            this.selectedListLabel.TabIndex = 2;
            this.selectedListLabel.Text = "Wybrana lista:";
            this.selectedListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // navigationPanel
            // 
            this.navigationPanel.Controls.Add(this.documentsLabel);
            this.navigationPanel.Controls.Add(this.fileManagementLabel);
            this.navigationPanel.Controls.Add(this.toolListLabel);
            this.navigationPanel.Controls.Add(this.basicDataLabel);
            this.navigationPanel.Location = new System.Drawing.Point(0, 127);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(900, 33);
            this.navigationPanel.TabIndex = 9;
            // 
            // documentsLabel
            // 
            this.documentsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.documentsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.documentsLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.documentsLabel.ForeColor = System.Drawing.Color.White;
            this.documentsLabel.Location = new System.Drawing.Point(696, 3);
            this.documentsLabel.Name = "documentsLabel";
            this.documentsLabel.Size = new System.Drawing.Size(191, 30);
            this.documentsLabel.TabIndex = 3;
            this.documentsLabel.Text = "Pozostałe dokumenty";
            this.documentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.documentsLabel.Click += new System.EventHandler(this.ModeLabel_Click);
            // 
            // fileManagementLabel
            // 
            this.fileManagementLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.fileManagementLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileManagementLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileManagementLabel.ForeColor = System.Drawing.Color.White;
            this.fileManagementLabel.Location = new System.Drawing.Point(468, 3);
            this.fileManagementLabel.Name = "fileManagementLabel";
            this.fileManagementLabel.Size = new System.Drawing.Size(191, 30);
            this.fileManagementLabel.TabIndex = 2;
            this.fileManagementLabel.Text = "Zarządzanie plikami";
            this.fileManagementLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fileManagementLabel.Click += new System.EventHandler(this.ModeLabel_Click);
            // 
            // toolListLabel
            // 
            this.toolListLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.toolListLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolListLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolListLabel.ForeColor = System.Drawing.Color.White;
            this.toolListLabel.Location = new System.Drawing.Point(240, 3);
            this.toolListLabel.Name = "toolListLabel";
            this.toolListLabel.Size = new System.Drawing.Size(191, 30);
            this.toolListLabel.TabIndex = 1;
            this.toolListLabel.Text = "Lista Narzędzi";
            this.toolListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolListLabel.Click += new System.EventHandler(this.ModeLabel_Click);
            // 
            // basicDataLabel
            // 
            this.basicDataLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.basicDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.basicDataLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.basicDataLabel.ForeColor = System.Drawing.Color.White;
            this.basicDataLabel.Location = new System.Drawing.Point(12, 3);
            this.basicDataLabel.Name = "basicDataLabel";
            this.basicDataLabel.Size = new System.Drawing.Size(191, 30);
            this.basicDataLabel.TabIndex = 0;
            this.basicDataLabel.Text = "Podstawowe Dane";
            this.basicDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.basicDataLabel.Click += new System.EventHandler(this.ModeLabel_Click);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.descriptionPanel);
            this.topPanel.Controls.Add(this.navigationPanel);
            this.topPanel.Controls.Add(this.selectedListPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(900, 160);
            this.topPanel.TabIndex = 10;
            // 
            // viewPanel
            // 
            this.viewPanel.AutoScroll = true;
            this.viewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 160);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(900, 620);
            this.viewPanel.TabIndex = 11;
            // 
            // ToolListManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 780);
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToolListManager";
            this.Text = "ToolListManager";
            this.Resize += new System.EventHandler(this.ToolListManager_Resize);
            this.descriptionPanel.ResumeLayout(false);
            this.selectedListPanel.ResumeLayout(false);
            this.listIdPanel.ResumeLayout(false);
            this.listIdTextBoxPanel.ResumeLayout(false);
            this.listIdTextBoxPanel.PerformLayout();
            this.browseListIdPanel.ResumeLayout(false);
            this.navigationPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel descriptionPanel;
        private Label moduleDescriptionLabel;
        private Panel selectedListPanel;
        private Label selectedListLabel;
        private Panel listIdPanel;
        private Panel listIdTextBoxPanel;
        private TextBox listIdTextBox;
        private Panel browseListIdPanel;
        private Button browselistIdButton;
        private Button loadListButton;
        private Panel navigationPanel;
        private Label basicDataLabel;
        private Label documentsLabel;
        private Label fileManagementLabel;
        private Label toolListLabel;
        private Panel topPanel;
        private Button deleteListButton;
        private Button saveListButton;
        private Panel viewPanel;
    }
}