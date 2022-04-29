using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolListHelperLibrary;
using ToolListHelperLibrary.Models;
using ToolListHelperUI.Interfaces;

namespace ToolListHelperUI.ToolListManagerClasses
{
    public partial class ToolListBasicData : Form, IThemeLoader, IBrowseData
    {
        public ToolListBasicData()
        {
            InitializeComponent();
        }

        internal void LoadListData(ListBrowsingModel model)
        {
            programNameTextBox.Text = model.Name;
            programDescriptionTextBox.Text = model.Description;
            operationTextBox.Text = model.Operation;
            drawingTextBox.Text = model.Drawing;
            materialTextBox.Text = model.Material;
            machineTextBox.Text = model.Machine;
            machineGroupTextBox.Text = model.MachineGroup;
            clampingTextBox.Text = model.Clamping;
            switch (model.ListType)
            {
                case ListType.Primary:
                    primaryTypeRadioButton.Checked = true;
                    break;
                case ListType.Secondary:
                    secondaryTypeRadioButton.Checked = true;
                    break;
                default:
                    break;
            }
            status1TextBox.Text = model.Status1;
            status2TextBox.Text = model.Status2;
            partClassTextBox.Text = model.WorkpieceClass;
            userTextBox.Text = model.UserName;
            LoadLogFileData(model.LogEntries);
        }

        private void LoadLogFileData(List<LogEntry> logEntries)
        {
            logFileDataGridView.DataSource = null;
            logFileDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(logEntries.Select(l => (LogEntryViewModel)l));
            logFileDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            logFileDataGridView.Columns["Note"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            logFileDataGridView.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            logFileDataGridView.Columns["Date"].DefaultCellStyle.Format = @"dd/MM/yyyy HH:mm:ss";
        }

        private void ToolListBasicData_Resize(object sender, EventArgs e)
        {
            leftPanel.Width = Width / 2;
            rightPanel.Width = Width / 2;
            foreach (Control control in leftPanel.Controls)
            {
                foreach (Panel panel in control.Controls.OfType<Panel>())
                {
                    panel.Width = Width / 4;
                }
            }
            foreach (Control control in rightPanel.Controls)
            {
                foreach (Panel panel in control.Controls.OfType<Panel>())
                {
                    panel.Width = Width / 4;
                }
            }
            //int radioWidth = listTypeRadiosPanel.Width / 2;
            //primaryTypeRadioButton.Width = radioWidth;
            //secondaryTypeRadioButton.Width = radioWidth;
        }

        private void ProgramNameTextBox_MouseEnter(object sender, EventArgs e)
        {
            //Button button = programNameTextBox.Controls.OfType<Button>().First();
            //button.Visible = true;
        }

        private void ProgramNameTextBox_MouseLeave(object sender, EventArgs e)
        {
            //Button button = programNameTextBox.Controls.OfType<Button>().First();
            //button.Visible = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            foreach (TextBox textBox in UserInterfaceLogic.GetAllControls<TextBox>(leftPanel))
            {
                Button button = new()
                {
                    Size = new(21, 21),
                    FlatStyle = FlatStyle.Flat,
                    Dock = DockStyle.Right,
                    Cursor = Cursors.Default,
                    Text = "▼",
                    ForeColor = Color.FromArgb(1, 112, 184),
                    Visible = false
                };
                button.FlatAppearance.BorderColor = Color.FromArgb(1, 112, 184);
                button.Font = new("Segoe UI", 9, FontStyle.Bold);
                //button.Click += (object sender, EventArgs e) => { MessageBox.Show("sss"); textBox.Focus(); } ;
                button.Click += Button_Click;
                textBox.Controls.Add(button);
                textBox.Enter += TextBox_Enter;
                textBox.KeyDown += TextBox_KeyDown;
                textBox.Leave += TextBox_Leave;
                InteropOperations.SendMessage(textBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(button.Width << 16));
            }
            base.OnLoad(e);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Control caller = (Control)sender;
            BrowseWindow browseWindow;
            switch (caller.Parent.Name)
            {
                case "programNameTextBox":
                    browseWindow = new(this, BrowsingMode.ProgramName, this);
                    browseWindow.Show();
                    break;
                case "programDescriptionTextBox":
                    browseWindow = new(this, BrowsingMode.ProgramDescription, this);
                    browseWindow.Show();
                    break;
                case "operationTextBox":
                    browseWindow = new(this, BrowsingMode.Operation, this);
                    browseWindow.Show();
                    break;
                case "drawingTextBox":
                    browseWindow = new(this, BrowsingMode.Drawing, this);
                    browseWindow.Show();
                    break;
                case "materialTextBox":
                    browseWindow = new(this, BrowsingMode.Material, this);
                    browseWindow.Show();
                    break;
                case "machineTextBox":
                    browseWindow = new(this, BrowsingMode.Machine, this);
                    browseWindow.Show();
                    break;
                case "machineGroupTextBox":
                    browseWindow = new(this, BrowsingMode.MachineGroup, this);
                    browseWindow.Show();
                    break;
                case "clampingTextBox":
                    browseWindow = new(this, BrowsingMode.Clamping, this);
                    browseWindow.Show();
                    break;
                case "status1TextBox":
                    browseWindow = new(this, BrowsingMode.Status1, this);
                    browseWindow.Show();
                    break;
                case "status2TextBox":
                    browseWindow = new(this, BrowsingMode.Status2, this);
                    browseWindow.Show();
                    break;
                case "partClassTextBox":
                    browseWindow = new(this, BrowsingMode.WorkpieceClass, this);
                    browseWindow.Show();
                    break;
                case "userTextBox":
                    browseWindow = new(this, BrowsingMode.UserName, this);
                    browseWindow.Show();
                    break;
                default:
                    throw new ArgumentException("Unsupported calling control", nameof(sender));
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                default:
                    break;
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Button button = textBox.Controls.OfType<Button>().First();
            button.Visible = true;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Button button = textBox.Controls.OfType<Button>().First();
            button.Visible = false;
        }


        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ProgramNameLabel.Focus();
            }
        }
        private void ListTypeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int index = e.Index >= 0 ? e.Index : 0;
            var brush = Enum.Parse<ApplicationTheme>(Properties.Settings.Default.ApplicationTheme) switch
            {
                ApplicationTheme.Dark => new SolidBrush(ApplicationThemes.DarkSecondaryFore),
                ApplicationTheme.Light => new SolidBrush(ApplicationThemes.LightSecondaryFore),
                _ => throw new InvalidOperationException()
            };
            //e.Graphics.DrawLines(new(brush), new Point[] {new(0,0), new(0, comboBox.Size.Height), new(comboBox.Size.Width, comboBox.Size.Height), new(comboBox.Size.Width, 0) });
            e.DrawBackground();
            e.Graphics.DrawString(comboBox.Items[index].ToString(), e.Font ?? new Font("Segoe UI", 10), brush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        public void LoadTheme(ApplicationTheme applicationTheme)
        {
            ApplicationThemes.ApplyTheme(this, applicationTheme);
        }

        public void LoadDataToUI(string[] dataStrings, BrowsingMode browsingMode)
        {
            switch (browsingMode)
            {
                case BrowsingMode.ProgramName:
                    programNameTextBox.Text = dataStrings[0];
                    break;
                case BrowsingMode.ProgramDescription:
                    programDescriptionLabel.Text = dataStrings[0];
                    break;
                case BrowsingMode.Machine:
                case BrowsingMode.MachineGroup:
                    machineTextBox.Text = dataStrings[0];
                    machineGroupTextBox.Text = dataStrings[1];
                    break;
                case BrowsingMode.Material:
                    materialTextBox.Text = dataStrings[0];
                    break;
                case BrowsingMode.Clamping:
                    clampingTextBox.Text = dataStrings[0];
                    break;
                case BrowsingMode.Drawing:
                    drawingTextBox.Text = dataStrings[0];
                    break;
                case BrowsingMode.Operation:
                    operationTextBox.Text = dataStrings[0];
                    break;
                case BrowsingMode.Status1:
                    status1TextBox.Text = dataStrings[0];
                    break;
                case BrowsingMode.Status2:
                    status2TextBox.Text = dataStrings[0];
                    break;
                case BrowsingMode.WorkpieceClass:
                    partClassTextBox.Text = dataStrings[0];
                    break;
                case BrowsingMode.UserName:
                    userTextBox.Text = dataStrings[0];
                    break;
                default:
                    break;
            }
        }
    }
}
