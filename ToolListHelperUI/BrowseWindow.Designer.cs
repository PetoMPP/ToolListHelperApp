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
            this.textBoxesPanel = new System.Windows.Forms.Panel();
            this.textBox3Panel = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2Panel = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1Panel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browseDataGridView)).BeginInit();
            this.textBoxesPanel.SuspendLayout();
            this.textBox3Panel.SuspendLayout();
            this.textBox2Panel.SuspendLayout();
            this.textBox1Panel.SuspendLayout();
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
            this.statusLabel.Size = new System.Drawing.Size(426, 20);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Ładowanie danych..";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxesPanel
            // 
            this.textBoxesPanel.Controls.Add(this.textBox3Panel);
            this.textBoxesPanel.Controls.Add(this.textBox2Panel);
            this.textBoxesPanel.Controls.Add(this.textBox1Panel);
            this.textBoxesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxesPanel.Location = new System.Drawing.Point(0, 0);
            this.textBoxesPanel.Name = "textBoxesPanel";
            this.textBoxesPanel.Size = new System.Drawing.Size(450, 35);
            this.textBoxesPanel.TabIndex = 3;
            // 
            // textBox3Panel
            // 
            this.textBox3Panel.Controls.Add(this.textBox3);
            this.textBox3Panel.Location = new System.Drawing.Point(300, 0);
            this.textBox3Panel.Name = "textBox3Panel";
            this.textBox3Panel.Padding = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.textBox3Panel.Size = new System.Drawing.Size(150, 35);
            this.textBox3Panel.TabIndex = 2;
            this.textBox3Panel.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.Location = new System.Drawing.Point(6, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(138, 27);
            this.textBox3.TabIndex = 0;
            // 
            // textBox2Panel
            // 
            this.textBox2Panel.Controls.Add(this.textBox2);
            this.textBox2Panel.Location = new System.Drawing.Point(150, 0);
            this.textBox2Panel.Name = "textBox2Panel";
            this.textBox2Panel.Padding = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.textBox2Panel.Size = new System.Drawing.Size(150, 35);
            this.textBox2Panel.TabIndex = 1;
            this.textBox2Panel.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(6, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 27);
            this.textBox2.TabIndex = 0;
            // 
            // textBox1Panel
            // 
            this.textBox1Panel.Controls.Add(this.textBox1);
            this.textBox1Panel.Location = new System.Drawing.Point(0, 0);
            this.textBox1Panel.Name = "textBox1Panel";
            this.textBox1Panel.Padding = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.textBox1Panel.Size = new System.Drawing.Size(150, 35);
            this.textBox1Panel.TabIndex = 0;
            this.textBox1Panel.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 27);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // BrowseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 561);
            this.Controls.Add(this.textBoxesPanel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.browseDataGridView);
            this.Controls.Add(this.buttonsPanel);
            this.Name = "BrowseWindow";
            this.Text = "BrowseWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BrowseWindow_FormClosed);
            this.buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browseDataGridView)).EndInit();
            this.textBoxesPanel.ResumeLayout(false);
            this.textBox3Panel.ResumeLayout(false);
            this.textBox3Panel.PerformLayout();
            this.textBox2Panel.ResumeLayout(false);
            this.textBox2Panel.PerformLayout();
            this.textBox1Panel.ResumeLayout(false);
            this.textBox1Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel buttonsPanel;
        private DataGridView browseDataGridView;
        private Button cancelButton;
        private Button okButton;
        private Label statusLabel;
        private Panel textBoxesPanel;
        private Panel textBox3Panel;
        private TextBox textBox3;
        private Panel textBox2Panel;
        private TextBox textBox2;
        private Panel textBox1Panel;
        private TextBox textBox1;
    }
}