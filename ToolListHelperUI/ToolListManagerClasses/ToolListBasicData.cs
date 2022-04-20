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
using ToolListHelperUI.Interfaces;

namespace ToolListHelperUI.ToolListManagerClasses
{
    public partial class ToolListBasicData : Form, IThemeLoader
    {
        public ToolListBasicData()
        {
            InitializeComponent();
        }

        internal void LoadListData()
        {
            throw new NotImplementedException();
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
                button.Click += (object sender, EventArgs e) => { MessageBox.Show("sss"); textBox.Focus(); } ;
                textBox.Controls.Add(button);
                textBox.Enter += TextBox_Enter;
                textBox.KeyDown += TextBox_KeyDown;
                textBox.Leave += TextBox_Leave;
                InteropOperations.SendMessage(textBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(button.Width << 16));
            }
            base.OnLoad(e);
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
    }
}
