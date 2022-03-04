namespace ToolListHelperUI
{
    partial class MainWindow
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
            this.sidePanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.reportIssuePanel = new System.Windows.Forms.Panel();
            this.reportIssueButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolListRemoverButton = new System.Windows.Forms.Button();
            this.datronDictatorButton = new System.Windows.Forms.Button();
            this.toolListMakerButton = new System.Windows.Forms.Button();
            this.menuLabel = new System.Windows.Forms.Label();
            this.logoLabel = new System.Windows.Forms.Label();
            this.currentModuleLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.closeAppButton = new System.Windows.Forms.Button();
            this.sidePanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.reportIssuePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.Controls.Add(this.menuPanel);
            this.sidePanel.Controls.Add(this.logoLabel);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(200, 844);
            this.sidePanel.TabIndex = 0;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.White;
            this.menuPanel.Controls.Add(this.reportIssuePanel);
            this.menuPanel.Controls.Add(this.pictureBox1);
            this.menuPanel.Controls.Add(this.toolListRemoverButton);
            this.menuPanel.Controls.Add(this.datronDictatorButton);
            this.menuPanel.Controls.Add(this.toolListMakerButton);
            this.menuPanel.Controls.Add(this.menuLabel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPanel.Location = new System.Drawing.Point(0, 100);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(200, 744);
            this.menuPanel.TabIndex = 2;
            // 
            // reportIssuePanel
            // 
            this.reportIssuePanel.Controls.Add(this.reportIssueButton);
            this.reportIssuePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.reportIssuePanel.Location = new System.Drawing.Point(0, 606);
            this.reportIssuePanel.Name = "reportIssuePanel";
            this.reportIssuePanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 20);
            this.reportIssuePanel.Size = new System.Drawing.Size(200, 80);
            this.reportIssuePanel.TabIndex = 9;
            // 
            // reportIssueButton
            // 
            this.reportIssueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(165)))), ((int)(((byte)(235)))));
            this.reportIssueButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportIssueButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.reportIssueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportIssueButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reportIssueButton.Location = new System.Drawing.Point(10, 10);
            this.reportIssueButton.Margin = new System.Windows.Forms.Padding(10);
            this.reportIssueButton.Name = "reportIssueButton";
            this.reportIssueButton.Size = new System.Drawing.Size(180, 50);
            this.reportIssueButton.TabIndex = 8;
            this.reportIssueButton.Text = "Zgłoś problem";
            this.reportIssueButton.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Image = global::ToolListHelperUI.Properties.Resources.Logo_Axito_Uhlmann_Group;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 686);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 58);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // toolListRemoverButton
            // 
            this.toolListRemoverButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(165)))), ((int)(((byte)(235)))));
            this.toolListRemoverButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.toolListRemoverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolListRemoverButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolListRemoverButton.Location = new System.Drawing.Point(10, 200);
            this.toolListRemoverButton.Margin = new System.Windows.Forms.Padding(10);
            this.toolListRemoverButton.Name = "toolListRemoverButton";
            this.toolListRemoverButton.Size = new System.Drawing.Size(180, 50);
            this.toolListRemoverButton.TabIndex = 5;
            this.toolListRemoverButton.Text = "Tool List Remover";
            this.toolListRemoverButton.UseVisualStyleBackColor = false;
            // 
            // datronDictatorButton
            // 
            this.datronDictatorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(165)))), ((int)(((byte)(235)))));
            this.datronDictatorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.datronDictatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.datronDictatorButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.datronDictatorButton.Location = new System.Drawing.Point(10, 130);
            this.datronDictatorButton.Margin = new System.Windows.Forms.Padding(10);
            this.datronDictatorButton.Name = "datronDictatorButton";
            this.datronDictatorButton.Size = new System.Drawing.Size(180, 50);
            this.datronDictatorButton.TabIndex = 4;
            this.datronDictatorButton.Text = "Datron Dictator";
            this.datronDictatorButton.UseVisualStyleBackColor = false;
            // 
            // toolListMakerButton
            // 
            this.toolListMakerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(165)))), ((int)(((byte)(235)))));
            this.toolListMakerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.toolListMakerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolListMakerButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolListMakerButton.Location = new System.Drawing.Point(10, 60);
            this.toolListMakerButton.Margin = new System.Windows.Forms.Padding(10);
            this.toolListMakerButton.Name = "toolListMakerButton";
            this.toolListMakerButton.Size = new System.Drawing.Size(180, 50);
            this.toolListMakerButton.TabIndex = 3;
            this.toolListMakerButton.Text = "Tool List Maker";
            this.toolListMakerButton.UseVisualStyleBackColor = false;
            this.toolListMakerButton.Click += new System.EventHandler(this.ToolListMakerButton_ClickAsync);
            // 
            // menuLabel
            // 
            this.menuLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.menuLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuLabel.ForeColor = System.Drawing.Color.White;
            this.menuLabel.Location = new System.Drawing.Point(0, 0);
            this.menuLabel.Name = "menuLabel";
            this.menuLabel.Size = new System.Drawing.Size(200, 40);
            this.menuLabel.TabIndex = 2;
            this.menuLabel.Text = "Applications Menu";
            this.menuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logoLabel
            // 
            this.logoLabel.BackColor = System.Drawing.Color.White;
            this.logoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.logoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.logoLabel.Location = new System.Drawing.Point(0, 0);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(200, 100);
            this.logoLabel.TabIndex = 0;
            this.logoLabel.Text = "Tool List Helper";
            // 
            // currentModuleLabel
            // 
            this.currentModuleLabel.BackColor = System.Drawing.Color.White;
            this.currentModuleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.currentModuleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.currentModuleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.currentModuleLabel.Location = new System.Drawing.Point(200, 0);
            this.currentModuleLabel.Name = "currentModuleLabel";
            this.currentModuleLabel.Size = new System.Drawing.Size(904, 60);
            this.currentModuleLabel.TabIndex = 1;
            this.currentModuleLabel.Text = "Uruchom aplikację korzystając z menu po lewej";
            this.currentModuleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(200, 60);
            this.mainPanel.MinimumSize = new System.Drawing.Size(10, 10);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(904, 784);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.Resize += new System.EventHandler(this.MainPanel_Resize);
            // 
            // closeAppButton
            // 
            this.closeAppButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeAppButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeAppButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeAppButton.Location = new System.Drawing.Point(1049, 10);
            this.closeAppButton.Name = "closeAppButton";
            this.closeAppButton.Size = new System.Drawing.Size(40, 40);
            this.closeAppButton.TabIndex = 0;
            this.closeAppButton.Text = "X";
            this.closeAppButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.closeAppButton.UseVisualStyleBackColor = false;
            this.closeAppButton.Visible = false;
            this.closeAppButton.Click += new System.EventHandler(this.CloseAppButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1104, 844);
            this.Controls.Add(this.closeAppButton);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.currentModuleLabel);
            this.Controls.Add(this.sidePanel);
            this.Name = "MainWindow";
            this.Text = "Tool List Helper";
            this.sidePanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.reportIssuePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel sidePanel;
        private Label logoLabel;
        private Panel menuPanel;
        private Label menuLabel;
        private Button toolListMakerButton;
        private Button toolListRemoverButton;
        private Button datronDictatorButton;
        private Label currentModuleLabel;
        private Panel mainPanel;
        private PictureBox pictureBox1;
        private Panel reportIssuePanel;
        private Button reportIssueButton;
        private Button closeAppButton;
    }
}