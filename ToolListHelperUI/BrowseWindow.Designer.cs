namespace ToolListHelperUI
{
    partial class BrowseWindow
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
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.browseDataGridView = new System.Windows.Forms.DataGridView();
            this.statusLabel = new System.Windows.Forms.Label();
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.cancelButton);
            this.buttonsPanel.Controls.Add(this.okButton);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 521);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(450, 40);
            this.buttonsPanel.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.cancelButton.Location = new System.Drawing.Point(385, 5);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(60, 30);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.okButton.Enabled = false;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.okButton.Location = new System.Drawing.Point(5, 5);
            this.okButton.Margin = new System.Windows.Forms.Padding(5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(60, 30);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // browseDataGridView
            // 
            this.browseDataGridView.AllowUserToAddRows = false;
            this.browseDataGridView.AllowUserToDeleteRows = false;
            this.browseDataGridView.AllowUserToOrderColumns = true;
            this.browseDataGridView.AllowUserToResizeRows = false;
            this.browseDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.browseDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.browseDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.browseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.browseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browseDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.browseDataGridView.Location = new System.Drawing.Point(0, 0);
            this.browseDataGridView.MultiSelect = false;
            this.browseDataGridView.Name = "browseDataGridView";
            this.browseDataGridView.ReadOnly = true;
            this.browseDataGridView.RowHeadersVisible = false;
            this.browseDataGridView.RowTemplate.Height = 25;
            this.browseDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.browseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.browseDataGridView.Size = new System.Drawing.Size(450, 521);
            this.browseDataGridView.TabIndex = 1;
            this.browseDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BrowseDataGridView_CellMouseDoubleClick);
            this.browseDataGridView.SelectionChanged += new System.EventHandler(this.BrowseDataGridView_SelectionChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(1, 250);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(448, 20);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Ładowanie danych..";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrowseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 561);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.browseDataGridView);
            this.Controls.Add(this.buttonsPanel);
            this.Name = "BrowseWindow";
            this.Text = "BrowseWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BrowseWindow_FormClosed);
            this.buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browseDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel buttonsPanel;
        private DataGridView browseDataGridView;
        private Button cancelButton;
        private Button okButton;
        private Label statusLabel;
    }
}