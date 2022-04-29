namespace ToolListHelperUI
{
    partial class ToolPicker
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
            this.currentModuleLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.applyButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolQuantityTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolPositionTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolOrderCodeTextBox = new System.Windows.Forms.TextBox();
            this.orderCodeLabel = new System.Windows.Forms.Label();
            this.toolDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.toolIdTextBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolRadioButton = new System.Windows.Forms.RadioButton();
            this.compRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // currentModuleLabel
            // 
            this.currentModuleLabel.BackColor = System.Drawing.Color.White;
            this.currentModuleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.currentModuleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.currentModuleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.currentModuleLabel.Location = new System.Drawing.Point(0, 0);
            this.currentModuleLabel.Name = "currentModuleLabel";
            this.currentModuleLabel.Padding = new System.Windows.Forms.Padding(10);
            this.currentModuleLabel.Size = new System.Drawing.Size(400, 60);
            this.currentModuleLabel.TabIndex = 2;
            this.currentModuleLabel.Text = "Wybierz narzędzie";
            this.currentModuleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 450);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 50);
            this.panel3.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.applyButton);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(266, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panel6.Size = new System.Drawing.Size(133, 50);
            this.panel6.TabIndex = 2;
            // 
            // applyButton
            // 
            this.applyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.applyButton.Location = new System.Drawing.Point(15, 10);
            this.applyButton.Margin = new System.Windows.Forms.Padding(5);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(103, 30);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Zastosuj";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cancelButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(133, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panel5.Size = new System.Drawing.Size(133, 50);
            this.panel5.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.cancelButton.Location = new System.Drawing.Point(15, 10);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(103, 30);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.okButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panel4.Size = new System.Drawing.Size(133, 50);
            this.panel4.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.okButton.Location = new System.Drawing.Point(15, 10);
            this.okButton.Margin = new System.Windows.Forms.Padding(5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(103, 30);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolQuantityTextBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.toolPositionTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.toolOrderCodeTextBox);
            this.panel1.Controls.Add(this.orderCodeLabel);
            this.panel1.Controls.Add(this.toolDescriptionTextBox);
            this.panel1.Controls.Add(this.descriptionLabel);
            this.panel1.Controls.Add(this.toolIdTextBox);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(25);
            this.panel1.Size = new System.Drawing.Size(400, 390);
            this.panel1.TabIndex = 5;
            // 
            // toolQuantityTextBox
            // 
            this.toolQuantityTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolQuantityTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolQuantityTextBox.Location = new System.Drawing.Point(25, 300);
            this.toolQuantityTextBox.MaxLength = 5;
            this.toolQuantityTextBox.Name = "toolQuantityTextBox";
            this.toolQuantityTextBox.ShortcutsEnabled = false;
            this.toolQuantityTextBox.Size = new System.Drawing.Size(350, 25);
            this.toolQuantityTextBox.TabIndex = 11;
            this.toolQuantityTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumericTextBox_KeyDown);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(25, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(350, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ilość:";
            // 
            // toolPositionTextBox
            // 
            this.toolPositionTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolPositionTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolPositionTextBox.Location = new System.Drawing.Point(25, 250);
            this.toolPositionTextBox.MaxLength = 5;
            this.toolPositionTextBox.Name = "toolPositionTextBox";
            this.toolPositionTextBox.ShortcutsEnabled = false;
            this.toolPositionTextBox.Size = new System.Drawing.Size(350, 25);
            this.toolPositionTextBox.TabIndex = 9;
            this.toolPositionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumericTextBox_KeyDown);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(25, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(350, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Pozycja:";
            // 
            // toolOrderCodeTextBox
            // 
            this.toolOrderCodeTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolOrderCodeTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolOrderCodeTextBox.Location = new System.Drawing.Point(25, 200);
            this.toolOrderCodeTextBox.Name = "toolOrderCodeTextBox";
            this.toolOrderCodeTextBox.Size = new System.Drawing.Size(350, 25);
            this.toolOrderCodeTextBox.TabIndex = 7;
            // 
            // orderCodeLabel
            // 
            this.orderCodeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.orderCodeLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.orderCodeLabel.Location = new System.Drawing.Point(25, 175);
            this.orderCodeLabel.Name = "orderCodeLabel";
            this.orderCodeLabel.Size = new System.Drawing.Size(350, 25);
            this.orderCodeLabel.TabIndex = 6;
            this.orderCodeLabel.Text = "<type> Order Code:";
            // 
            // toolDescriptionTextBox
            // 
            this.toolDescriptionTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolDescriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolDescriptionTextBox.Location = new System.Drawing.Point(25, 150);
            this.toolDescriptionTextBox.Name = "toolDescriptionTextBox";
            this.toolDescriptionTextBox.Size = new System.Drawing.Size(350, 25);
            this.toolDescriptionTextBox.TabIndex = 5;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionLabel.Location = new System.Drawing.Point(25, 125);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(350, 25);
            this.descriptionLabel.TabIndex = 4;
            this.descriptionLabel.Text = "<type> Description:";
            // 
            // toolIdTextBox
            // 
            this.toolIdTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolIdTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolIdTextBox.Location = new System.Drawing.Point(25, 100);
            this.toolIdTextBox.Name = "toolIdTextBox";
            this.toolIdTextBox.Size = new System.Drawing.Size(350, 25);
            this.toolIdTextBox.TabIndex = 3;
            // 
            // idLabel
            // 
            this.idLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.idLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.idLabel.Location = new System.Drawing.Point(25, 75);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(350, 25);
            this.idLabel.TabIndex = 2;
            this.idLabel.Text = "<type> Id:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolRadioButton);
            this.panel2.Controls.Add(this.compRadioButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(25, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 25);
            this.panel2.TabIndex = 1;
            // 
            // toolRadioButton
            // 
            this.toolRadioButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolRadioButton.Location = new System.Drawing.Point(175, 0);
            this.toolRadioButton.Name = "toolRadioButton";
            this.toolRadioButton.Size = new System.Drawing.Size(175, 25);
            this.toolRadioButton.TabIndex = 1;
            this.toolRadioButton.TabStop = true;
            this.toolRadioButton.Text = "Złożenie";
            this.toolRadioButton.UseVisualStyleBackColor = true;
            // 
            // compRadioButton
            // 
            this.compRadioButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.compRadioButton.Location = new System.Drawing.Point(0, 0);
            this.compRadioButton.Name = "compRadioButton";
            this.compRadioButton.Size = new System.Drawing.Size(175, 25);
            this.compRadioButton.TabIndex = 0;
            this.compRadioButton.TabStop = true;
            this.compRadioButton.Text = "Komponent";
            this.compRadioButton.UseVisualStyleBackColor = true;
            this.compRadioButton.CheckedChanged += new System.EventHandler(this.CompRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Typ narzędzia:";
            // 
            // ToolPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.currentModuleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ToolPicker";
            this.Text = "ToolPicker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ToolPicker_FormClosed);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label currentModuleLabel;
        private Panel panel3;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Panel panel1;
        private TextBox toolQuantityTextBox;
        private Label label6;
        private TextBox toolPositionTextBox;
        private Label label5;
        private TextBox toolOrderCodeTextBox;
        private Label orderCodeLabel;
        private TextBox toolDescriptionTextBox;
        private Label descriptionLabel;
        private TextBox toolIdTextBox;
        private Label idLabel;
        private Panel panel2;
        private RadioButton toolRadioButton;
        private RadioButton compRadioButton;
        private Label label1;
        private Button applyButton;
        private Button cancelButton;
        private Button okButton;
    }
}