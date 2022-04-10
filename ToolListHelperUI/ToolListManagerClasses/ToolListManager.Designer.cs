﻿namespace ToolListHelperUI.ToolListManagerClasses
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
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.documentsLabel = new System.Windows.Forms.Label();
            this.fileManagementLabel = new System.Windows.Forms.Label();
            this.toolListLabel = new System.Windows.Forms.Label();
            this.basicDataLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.selectedListPanel = new System.Windows.Forms.Panel();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.deleteListButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.saveListButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.loadListButton = new System.Windows.Forms.Button();
            this.listIdPanel = new System.Windows.Forms.Panel();
            this.listIdTextBoxPanel = new System.Windows.Forms.Panel();
            this.listIdTextBox = new System.Windows.Forms.TextBox();
            this.browseListIdPanel = new System.Windows.Forms.Panel();
            this.browselistIdButton = new System.Windows.Forms.Button();
            this.selectedListLabel = new System.Windows.Forms.Label();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.descriptionPanel.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.selectedListPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.listIdPanel.SuspendLayout();
            this.listIdTextBoxPanel.SuspendLayout();
            this.browseListIdPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // descriptionPanel
            // 
            this.descriptionPanel.AutoScroll = true;
            this.descriptionPanel.Controls.Add(this.moduleDescriptionLabel);
            this.descriptionPanel.Dock = System.Windows.Forms.DockStyle.Top;
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
            // navigationPanel
            // 
            this.navigationPanel.Controls.Add(this.documentsLabel);
            this.navigationPanel.Controls.Add(this.fileManagementLabel);
            this.navigationPanel.Controls.Add(this.toolListLabel);
            this.navigationPanel.Controls.Add(this.basicDataLabel);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navigationPanel.Location = new System.Drawing.Point(0, 127);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(900, 33);
            this.navigationPanel.TabIndex = 9;
            // 
            // documentsLabel
            // 
            this.documentsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.documentsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.documentsLabel.Enabled = false;
            this.documentsLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.documentsLabel.ForeColor = System.Drawing.Color.White;
            this.documentsLabel.Location = new System.Drawing.Point(697, 3);
            this.documentsLabel.Margin = new System.Windows.Forms.Padding(22, 0, 22, 0);
            this.documentsLabel.Name = "documentsLabel";
            this.documentsLabel.Size = new System.Drawing.Size(180, 30);
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
            this.fileManagementLabel.Location = new System.Drawing.Point(472, 3);
            this.fileManagementLabel.Margin = new System.Windows.Forms.Padding(22, 0, 22, 0);
            this.fileManagementLabel.Name = "fileManagementLabel";
            this.fileManagementLabel.Size = new System.Drawing.Size(180, 30);
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
            this.toolListLabel.Location = new System.Drawing.Point(247, 3);
            this.toolListLabel.Margin = new System.Windows.Forms.Padding(22, 0, 22, 0);
            this.toolListLabel.Name = "toolListLabel";
            this.toolListLabel.Size = new System.Drawing.Size(180, 30);
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
            this.basicDataLabel.Location = new System.Drawing.Point(22, 3);
            this.basicDataLabel.Margin = new System.Windows.Forms.Padding(22, 0, 22, 0);
            this.basicDataLabel.Name = "basicDataLabel";
            this.basicDataLabel.Size = new System.Drawing.Size(180, 30);
            this.basicDataLabel.TabIndex = 0;
            this.basicDataLabel.Text = "Podstawowe Dane";
            this.basicDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.basicDataLabel.Click += new System.EventHandler(this.ModeLabel_Click);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.selectedListPanel);
            this.topPanel.Controls.Add(this.descriptionPanel);
            this.topPanel.Controls.Add(this.navigationPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(900, 160);
            this.topPanel.TabIndex = 10;
            // 
            // selectedListPanel
            // 
            this.selectedListPanel.Controls.Add(this.buttonsPanel);
            this.selectedListPanel.Controls.Add(this.listIdPanel);
            this.selectedListPanel.Controls.Add(this.selectedListLabel);
            this.selectedListPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectedListPanel.Location = new System.Drawing.Point(0, 80);
            this.selectedListPanel.Name = "selectedListPanel";
            this.selectedListPanel.Size = new System.Drawing.Size(900, 47);
            this.selectedListPanel.TabIndex = 10;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.deleteListButton);
            this.buttonsPanel.Controls.Add(this.label2);
            this.buttonsPanel.Controls.Add(this.saveListButton);
            this.buttonsPanel.Controls.Add(this.label1);
            this.buttonsPanel.Controls.Add(this.loadListButton);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsPanel.Location = new System.Drawing.Point(525, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Padding = new System.Windows.Forms.Padding(8);
            this.buttonsPanel.Size = new System.Drawing.Size(375, 47);
            this.buttonsPanel.TabIndex = 7;
            // 
            // deleteListButton
            // 
            this.deleteListButton.BackColor = System.Drawing.Color.White;
            this.deleteListButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteListButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.deleteListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteListButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteListButton.ForeColor = System.Drawing.Color.DarkRed;
            this.deleteListButton.Location = new System.Drawing.Point(250, 8);
            this.deleteListButton.Margin = new System.Windows.Forms.Padding(10);
            this.deleteListButton.Name = "deleteListButton";
            this.deleteListButton.Size = new System.Drawing.Size(116, 31);
            this.deleteListButton.TabIndex = 10;
            this.deleteListButton.Text = "Usuń listę";
            this.deleteListButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(245, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(5, 31);
            this.label2.TabIndex = 9;
            // 
            // saveListButton
            // 
            this.saveListButton.BackColor = System.Drawing.Color.White;
            this.saveListButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.saveListButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.saveListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveListButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveListButton.ForeColor = System.Drawing.Color.Green;
            this.saveListButton.Location = new System.Drawing.Point(129, 8);
            this.saveListButton.Margin = new System.Windows.Forms.Padding(10);
            this.saveListButton.Name = "saveListButton";
            this.saveListButton.Size = new System.Drawing.Size(116, 31);
            this.saveListButton.TabIndex = 8;
            this.saveListButton.Text = "Zapisz zmiany";
            this.saveListButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(124, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(5, 31);
            this.label1.TabIndex = 7;
            // 
            // loadListButton
            // 
            this.loadListButton.BackColor = System.Drawing.Color.White;
            this.loadListButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.loadListButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.loadListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadListButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadListButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.loadListButton.Location = new System.Drawing.Point(8, 8);
            this.loadListButton.Margin = new System.Windows.Forms.Padding(10);
            this.loadListButton.Name = "loadListButton";
            this.loadListButton.Size = new System.Drawing.Size(116, 31);
            this.loadListButton.TabIndex = 6;
            this.loadListButton.Text = "Załaduj listę";
            this.loadListButton.UseVisualStyleBackColor = false;
            // 
            // listIdPanel
            // 
            this.listIdPanel.Controls.Add(this.listIdTextBoxPanel);
            this.listIdPanel.Controls.Add(this.browseListIdPanel);
            this.listIdPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.listIdPanel.Location = new System.Drawing.Point(300, 0);
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
            this.selectedListLabel.Size = new System.Drawing.Size(300, 47);
            this.selectedListLabel.TabIndex = 2;
            this.selectedListLabel.Text = "Wybrana lista:";
            this.selectedListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // viewPanel
            // 
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
            this.navigationPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.selectedListPanel.ResumeLayout(false);
            this.buttonsPanel.ResumeLayout(false);
            this.listIdPanel.ResumeLayout(false);
            this.listIdTextBoxPanel.ResumeLayout(false);
            this.listIdTextBoxPanel.PerformLayout();
            this.browseListIdPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel descriptionPanel;
        private Label moduleDescriptionLabel;
        private Panel navigationPanel;
        private Label basicDataLabel;
        private Label documentsLabel;
        private Label fileManagementLabel;
        private Label toolListLabel;
        private Panel topPanel;
        private Panel viewPanel;
        private Panel selectedListPanel;
        private Button loadListButton;
        private Panel listIdPanel;
        private Panel listIdTextBoxPanel;
        private TextBox listIdTextBox;
        private Panel browseListIdPanel;
        private Button browselistIdButton;
        private Label selectedListLabel;
        private Panel buttonsPanel;
        private Button deleteListButton;
        private Label label2;
        private Button saveListButton;
        private Label label1;
    }
}