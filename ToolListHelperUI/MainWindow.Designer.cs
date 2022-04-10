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
            this.toolListManagerButton = new System.Windows.Forms.Button();
            this.reportIssuePanel = new System.Windows.Forms.Panel();
            this.reportIssueButton = new System.Windows.Forms.Button();
            this.axitoPictureBox = new System.Windows.Forms.PictureBox();
            this.toolListRemoverButton = new System.Windows.Forms.Button();
            this.datronDictatorButton = new System.Windows.Forms.Button();
            this.toolListMakerButton = new System.Windows.Forms.Button();
            this.menuLabel = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.currentModuleLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.closeAppButton = new System.Windows.Forms.Button();
            this.sidePanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.reportIssuePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axitoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.Controls.Add(this.menuPanel);
            this.sidePanel.Controls.Add(this.logoPictureBox);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(200, 844);
            this.sidePanel.TabIndex = 0;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.White;
            this.menuPanel.Controls.Add(this.toolListManagerButton);
            this.menuPanel.Controls.Add(this.reportIssuePanel);
            this.menuPanel.Controls.Add(this.axitoPictureBox);
            this.menuPanel.Controls.Add(this.toolListRemoverButton);
            this.menuPanel.Controls.Add(this.datronDictatorButton);
            this.menuPanel.Controls.Add(this.toolListMakerButton);
            this.menuPanel.Controls.Add(this.menuLabel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPanel.Location = new System.Drawing.Point(0, 100);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(200, 744);
            this.menuPanel.TabIndex = 9;
            // 
            // toolListManagerButton
            // 
            this.toolListManagerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(165)))), ((int)(((byte)(235)))));
            this.toolListManagerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.toolListManagerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolListManagerButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolListManagerButton.Location = new System.Drawing.Point(10, 130);
            this.toolListManagerButton.Margin = new System.Windows.Forms.Padding(10);
            this.toolListManagerButton.Name = "toolListManagerButton";
            this.toolListManagerButton.Size = new System.Drawing.Size(180, 50);
            this.toolListManagerButton.TabIndex = 11;
            this.toolListManagerButton.Text = "Tool List Manager";
            this.toolListManagerButton.UseVisualStyleBackColor = false;
            this.toolListManagerButton.Click += new System.EventHandler(this.ToolListManagerButton_Click);
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
            this.reportIssueButton.Click += new System.EventHandler(this.ReportIssueButton_Click);
            // 
            // axitoPictureBox
            // 
            this.axitoPictureBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.axitoPictureBox.Image = global::ToolListHelperUI.Properties.Resources.Logo_Axito_Uhlmann_Group;
            this.axitoPictureBox.InitialImage = null;
            this.axitoPictureBox.Location = new System.Drawing.Point(0, 686);
            this.axitoPictureBox.Margin = new System.Windows.Forms.Padding(10);
            this.axitoPictureBox.Name = "axitoPictureBox";
            this.axitoPictureBox.Size = new System.Drawing.Size(200, 58);
            this.axitoPictureBox.TabIndex = 7;
            this.axitoPictureBox.TabStop = false;
            // 
            // toolListRemoverButton
            // 
            this.toolListRemoverButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(165)))), ((int)(((byte)(235)))));
            this.toolListRemoverButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.toolListRemoverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolListRemoverButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolListRemoverButton.Location = new System.Drawing.Point(10, 200);
            this.toolListRemoverButton.Margin = new System.Windows.Forms.Padding(10);
            this.toolListRemoverButton.Name = "toolListRemoverButton";
            this.toolListRemoverButton.Size = new System.Drawing.Size(180, 50);
            this.toolListRemoverButton.TabIndex = 5;
            this.toolListRemoverButton.Text = "Tool List Remover";
            this.toolListRemoverButton.UseVisualStyleBackColor = false;
            this.toolListRemoverButton.Click += new System.EventHandler(this.ToolListRemoverButton_Click);
            // 
            // datronDictatorButton
            // 
            this.datronDictatorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(165)))), ((int)(((byte)(235)))));
            this.datronDictatorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.datronDictatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.datronDictatorButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.datronDictatorButton.Location = new System.Drawing.Point(10, 130);
            this.datronDictatorButton.Margin = new System.Windows.Forms.Padding(10);
            this.datronDictatorButton.Name = "datronDictatorButton";
            this.datronDictatorButton.Size = new System.Drawing.Size(180, 50);
            this.datronDictatorButton.TabIndex = 4;
            this.datronDictatorButton.Text = "Datron Dictator";
            this.datronDictatorButton.UseVisualStyleBackColor = false;
            this.datronDictatorButton.Click += new System.EventHandler(this.DatronDictatorButton_Click);
            // 
            // toolListMakerButton
            // 
            this.toolListMakerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(165)))), ((int)(((byte)(235)))));
            this.toolListMakerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(60)))), ((int)(((byte)(111)))));
            this.toolListMakerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolListMakerButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolListMakerButton.Location = new System.Drawing.Point(10, 60);
            this.toolListMakerButton.Margin = new System.Windows.Forms.Padding(10);
            this.toolListMakerButton.Name = "toolListMakerButton";
            this.toolListMakerButton.Size = new System.Drawing.Size(180, 50);
            this.toolListMakerButton.TabIndex = 3;
            this.toolListMakerButton.Text = "Tool List Maker";
            this.toolListMakerButton.UseVisualStyleBackColor = false;
            this.toolListMakerButton.Click += new System.EventHandler(this.ToolListMakerButton_ClickAsync);
            this.toolListMakerButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolListMakerButton_MouseDown);
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
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPictureBox.Image = global::ToolListHelperUI.Properties.Resources.TLHLOGO;
            this.logoPictureBox.InitialImage = null;
            this.logoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(10);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(200, 100);
            this.logoPictureBox.TabIndex = 8;
            this.logoPictureBox.TabStop = false;
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
            this.Icon = global::ToolListHelperUI.Properties.Resources.icon;
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Text = "Tool List Helper";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.sidePanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.reportIssuePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axitoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel sidePanel;
        private Label currentModuleLabel;
        private Panel mainPanel;
        private Button closeAppButton;
        private Panel menuPanel;
        private Panel reportIssuePanel;
        private Button reportIssueButton;
        private PictureBox axitoPictureBox;
        private Button toolListRemoverButton;
        private Button datronDictatorButton;
        private Button toolListMakerButton;
        private Label menuLabel;
        private PictureBox logoPictureBox;
        private Button toolListManagerButton;
    }
}