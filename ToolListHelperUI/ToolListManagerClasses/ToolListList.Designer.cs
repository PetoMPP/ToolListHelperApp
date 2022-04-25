namespace ToolListHelperUI.ToolListManagerClasses
{
    partial class ToolListList
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.listDataGridView = new System.Windows.Forms.DataGridView();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.listDataGridView);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(8);
            this.topPanel.Size = new System.Drawing.Size(900, 620);
            this.topPanel.TabIndex = 1;
            // 
            // listDataGridView
            // 
            this.listDataGridView.AllowUserToAddRows = false;
            this.listDataGridView.AllowUserToDeleteRows = false;
            this.listDataGridView.AllowUserToOrderColumns = true;
            this.listDataGridView.AllowUserToResizeRows = false;
            this.listDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.listDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.listDataGridView.Location = new System.Drawing.Point(8, 8);
            this.listDataGridView.MultiSelect = false;
            this.listDataGridView.Name = "listDataGridView";
            this.listDataGridView.ReadOnly = true;
            this.listDataGridView.RowHeadersVisible = false;
            this.listDataGridView.RowTemplate.Height = 25;
            this.listDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listDataGridView.Size = new System.Drawing.Size(884, 604);
            this.listDataGridView.TabIndex = 5;
            // 
            // ToolListList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToolListList";
            this.Text = "ToolListList";
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel topPanel;
        private DataGridView listDataGridView;
    }
}