
namespace ToolListHelperUI
{
    partial class ToolListRemover
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
            this.programLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.toolListListBoxPanel = new System.Windows.Forms.Panel();
            this.listIdsTextBox = new System.Windows.Forms.TextBox();
            this.toolListsLabel = new System.Windows.Forms.Label();
            this.actionsPanel = new System.Windows.Forms.Panel();
            this.deleteToolListsPanel = new System.Windows.Forms.Panel();
            this.deleteToolListsButton = new System.Windows.Forms.Button();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.deleteNcFilesOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.deletingOptionsLabel = new System.Windows.Forms.Label();
            this.separatedByNewLineRadioButton = new System.Windows.Forms.RadioButton();
            this.separatedByCommaRadioButton = new System.Windows.Forms.RadioButton();
            this.separatorLabel = new System.Windows.Forms.Label();
            this.optionsLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.toolListListBoxPanel.SuspendLayout();
            this.actionsPanel.SuspendLayout();
            this.deleteToolListsPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // programLabel
            // 
            this.programLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.programLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.programLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.programLabel.Location = new System.Drawing.Point(0, 0);
            this.programLabel.Name = "programLabel";
            this.programLabel.Size = new System.Drawing.Size(800, 60);
            this.programLabel.TabIndex = 1;
            this.programLabel.Text = "Tool List Remover by PetoMPP";
            this.programLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mainSplitContainer);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 390);
            this.mainPanel.TabIndex = 2;
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.IsSplitterFixed = true;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.toolListListBoxPanel);
            this.mainSplitContainer.Panel1.Controls.Add(this.toolListsLabel);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.actionsPanel);
            this.mainSplitContainer.Panel2.Controls.Add(this.optionsPanel);
            this.mainSplitContainer.Size = new System.Drawing.Size(800, 390);
            this.mainSplitContainer.SplitterDistance = 295;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // toolListListBoxPanel
            // 
            this.toolListListBoxPanel.Controls.Add(this.listIdsTextBox);
            this.toolListListBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolListListBoxPanel.Location = new System.Drawing.Point(0, 89);
            this.toolListListBoxPanel.Name = "toolListListBoxPanel";
            this.toolListListBoxPanel.Padding = new System.Windows.Forms.Padding(6);
            this.toolListListBoxPanel.Size = new System.Drawing.Size(295, 301);
            this.toolListListBoxPanel.TabIndex = 5;
            // 
            // listIdsTextBox
            // 
            this.listIdsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listIdsTextBox.Location = new System.Drawing.Point(6, 6);
            this.listIdsTextBox.Multiline = true;
            this.listIdsTextBox.Name = "listIdsTextBox";
            this.listIdsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listIdsTextBox.Size = new System.Drawing.Size(283, 289);
            this.listIdsTextBox.TabIndex = 0;
            // 
            // toolListsLabel
            // 
            this.toolListsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolListsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolListsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.toolListsLabel.Location = new System.Drawing.Point(0, 0);
            this.toolListsLabel.Name = "toolListsLabel";
            this.toolListsLabel.Size = new System.Drawing.Size(295, 89);
            this.toolListsLabel.TabIndex = 2;
            this.toolListsLabel.Text = "Wprowadź numer(y) ID List(y):";
            this.toolListsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // actionsPanel
            // 
            this.actionsPanel.Controls.Add(this.deleteToolListsPanel);
            this.actionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionsPanel.Location = new System.Drawing.Point(0, 187);
            this.actionsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.actionsPanel.Size = new System.Drawing.Size(501, 203);
            this.actionsPanel.TabIndex = 9;
            // 
            // deleteToolListsPanel
            // 
            this.deleteToolListsPanel.Controls.Add(this.deleteToolListsButton);
            this.deleteToolListsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteToolListsPanel.Location = new System.Drawing.Point(4, 0);
            this.deleteToolListsPanel.Name = "deleteToolListsPanel";
            this.deleteToolListsPanel.Padding = new System.Windows.Forms.Padding(20);
            this.deleteToolListsPanel.Size = new System.Drawing.Size(493, 203);
            this.deleteToolListsPanel.TabIndex = 12;
            // 
            // deleteToolListsButton
            // 
            this.deleteToolListsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteToolListsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.deleteToolListsButton.FlatAppearance.BorderSize = 2;
            this.deleteToolListsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.deleteToolListsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.deleteToolListsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteToolListsButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteToolListsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.deleteToolListsButton.Location = new System.Drawing.Point(20, 20);
            this.deleteToolListsButton.Name = "deleteToolListsButton";
            this.deleteToolListsButton.Size = new System.Drawing.Size(453, 163);
            this.deleteToolListsButton.TabIndex = 0;
            this.deleteToolListsButton.Text = "Usuń Listy Narzędziowe!";
            this.deleteToolListsButton.UseVisualStyleBackColor = true;
            this.deleteToolListsButton.Click += new System.EventHandler(this.DeleteToolListsButton_Click);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.deleteNcFilesOnlyCheckBox);
            this.optionsPanel.Controls.Add(this.deletingOptionsLabel);
            this.optionsPanel.Controls.Add(this.separatedByNewLineRadioButton);
            this.optionsPanel.Controls.Add(this.separatedByCommaRadioButton);
            this.optionsPanel.Controls.Add(this.separatorLabel);
            this.optionsPanel.Controls.Add(this.optionsLabel);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionsPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.optionsPanel.Size = new System.Drawing.Size(501, 187);
            this.optionsPanel.TabIndex = 8;
            // 
            // deleteNcFilesOnlyCheckBox
            // 
            this.deleteNcFilesOnlyCheckBox.AutoSize = true;
            this.deleteNcFilesOnlyCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.deleteNcFilesOnlyCheckBox.Location = new System.Drawing.Point(4, 138);
            this.deleteNcFilesOnlyCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteNcFilesOnlyCheckBox.Name = "deleteNcFilesOnlyCheckBox";
            this.deleteNcFilesOnlyCheckBox.Size = new System.Drawing.Size(493, 19);
            this.deleteNcFilesOnlyCheckBox.TabIndex = 18;
            this.deleteNcFilesOnlyCheckBox.Text = "Usuń tylko pliki NC";
            this.deleteNcFilesOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // deletingOptionsLabel
            // 
            this.deletingOptionsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.deletingOptionsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deletingOptionsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.deletingOptionsLabel.Location = new System.Drawing.Point(4, 108);
            this.deletingOptionsLabel.Name = "deletingOptionsLabel";
            this.deletingOptionsLabel.Size = new System.Drawing.Size(493, 30);
            this.deletingOptionsLabel.TabIndex = 17;
            this.deletingOptionsLabel.Text = "Dodatkowe Opcje Usuwania:";
            this.deletingOptionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // separatedByNewLineRadioButton
            // 
            this.separatedByNewLineRadioButton.AutoSize = true;
            this.separatedByNewLineRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.separatedByNewLineRadioButton.Location = new System.Drawing.Point(4, 89);
            this.separatedByNewLineRadioButton.Name = "separatedByNewLineRadioButton";
            this.separatedByNewLineRadioButton.Size = new System.Drawing.Size(493, 19);
            this.separatedByNewLineRadioButton.TabIndex = 16;
            this.separatedByNewLineRadioButton.Text = "Nowy Wiersz";
            this.separatedByNewLineRadioButton.UseVisualStyleBackColor = true;
            // 
            // separatedByCommaRadioButton
            // 
            this.separatedByCommaRadioButton.AutoSize = true;
            this.separatedByCommaRadioButton.Checked = true;
            this.separatedByCommaRadioButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.separatedByCommaRadioButton.Location = new System.Drawing.Point(4, 70);
            this.separatedByCommaRadioButton.Name = "separatedByCommaRadioButton";
            this.separatedByCommaRadioButton.Size = new System.Drawing.Size(493, 19);
            this.separatedByCommaRadioButton.TabIndex = 15;
            this.separatedByCommaRadioButton.TabStop = true;
            this.separatedByCommaRadioButton.Text = "Przecinek (\",\")";
            this.separatedByCommaRadioButton.UseVisualStyleBackColor = true;
            // 
            // separatorLabel
            // 
            this.separatorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.separatorLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.separatorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.separatorLabel.Location = new System.Drawing.Point(4, 40);
            this.separatorLabel.Name = "separatorLabel";
            this.separatorLabel.Size = new System.Drawing.Size(493, 30);
            this.separatorLabel.TabIndex = 14;
            this.separatorLabel.Text = "Separator numerów ID List Narzędziowych:";
            this.separatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // optionsLabel
            // 
            this.optionsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.optionsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.optionsLabel.Location = new System.Drawing.Point(4, 0);
            this.optionsLabel.Name = "optionsLabel";
            this.optionsLabel.Size = new System.Drawing.Size(493, 40);
            this.optionsLabel.TabIndex = 7;
            this.optionsLabel.Text = "Opcje:";
            this.optionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToolListRemover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.programLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToolListRemover";
            this.Text = "Dashboard";
            this.mainPanel.ResumeLayout(false);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.toolListListBoxPanel.ResumeLayout(false);
            this.toolListListBoxPanel.PerformLayout();
            this.actionsPanel.ResumeLayout(false);
            this.deleteToolListsPanel.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label programLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.Label toolListsLabel;
        private System.Windows.Forms.Panel toolListListBoxPanel;
        private System.Windows.Forms.TextBox listIdsTextBox;
        private System.Windows.Forms.Panel actionsPanel;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.CheckBox deleteNcFilesOnlyCheckBox;
        private System.Windows.Forms.Label deletingOptionsLabel;
        private System.Windows.Forms.RadioButton separatedByNewLineRadioButton;
        private System.Windows.Forms.RadioButton separatedByCommaRadioButton;
        private System.Windows.Forms.Label separatorLabel;
        private System.Windows.Forms.Label optionsLabel;
        private Panel deleteToolListsPanel;
        private Button deleteToolListsButton;
    }
}