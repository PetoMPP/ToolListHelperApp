namespace ToolListHelperUI.ToolListManagerClasses
{
    partial class ToolListBasicData
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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.programNamePanel = new System.Windows.Forms.Panel();
            this.programNameTextBox = new System.Windows.Forms.TextBox();
            this.ProgramNameLabel = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.leftPanel.SuspendLayout();
            this.programNamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.programNamePanel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(450, 620);
            this.leftPanel.TabIndex = 0;
            // 
            // programNamePanel
            // 
            this.programNamePanel.Controls.Add(this.programNameTextBox);
            this.programNamePanel.Controls.Add(this.ProgramNameLabel);
            this.programNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.programNamePanel.Location = new System.Drawing.Point(0, 0);
            this.programNamePanel.Name = "programNamePanel";
            this.programNamePanel.Padding = new System.Windows.Forms.Padding(5);
            this.programNamePanel.Size = new System.Drawing.Size(450, 35);
            this.programNamePanel.TabIndex = 1;
            // 
            // programNameTextBox
            // 
            this.programNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programNameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.programNameTextBox.Location = new System.Drawing.Point(157, 5);
            this.programNameTextBox.Name = "programNameTextBox";
            this.programNameTextBox.Size = new System.Drawing.Size(288, 25);
            this.programNameTextBox.TabIndex = 4;
            this.programNameTextBox.MouseEnter += new System.EventHandler(this.ProgramNameTextBox_MouseEnter);
            this.programNameTextBox.MouseLeave += new System.EventHandler(this.ProgramNameTextBox_MouseLeave);
            // 
            // ProgramNameLabel
            // 
            this.ProgramNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProgramNameLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProgramNameLabel.Location = new System.Drawing.Point(5, 5);
            this.ProgramNameLabel.Name = "ProgramNameLabel";
            this.ProgramNameLabel.Size = new System.Drawing.Size(152, 25);
            this.ProgramNameLabel.TabIndex = 0;
            this.ProgramNameLabel.Text = "Nazwa Programu:";
            this.ProgramNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rightPanel
            // 
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.rightPanel.Location = new System.Drawing.Point(450, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(450, 620);
            this.rightPanel.TabIndex = 1;
            // 
            // ToolListBasicData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToolListBasicData";
            this.Text = "ToolListBasicData";
            this.Resize += new System.EventHandler(this.ToolListBasicData_Resize);
            this.leftPanel.ResumeLayout(false);
            this.programNamePanel.ResumeLayout(false);
            this.programNamePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel leftPanel;
        private Panel rightPanel;
        private Panel programNamePanel;
        private Label ProgramNameLabel;
        private TextBox programNameTextBox;
    }
}