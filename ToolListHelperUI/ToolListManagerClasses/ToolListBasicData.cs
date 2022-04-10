using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolListHelperUI.ToolListManagerClasses
{
    public partial class ToolListBasicData : Form
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
        }

        private void ProgramNameTextBox_MouseEnter(object sender, EventArgs e)
        {
            //programNameButton.Visible = true;
        }

        private void ProgramNameTextBox_MouseLeave(object sender, EventArgs e)
        {
            //programNameButton.Visible = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            var vart = leftPanel.Controls.OfType<Panel>().Select(p => p.Controls).Where(c => c.GetType() == typeof(TextBox));
            foreach (TextBox textBox in leftPanel.Controls)
            {
                Button button = new()
                {
                    Size = new(21, 21),
                    Location = new(2, textBox.ClientSize.Width - 22),
                    Cursor = Cursors.Default,
                    Text = "▼",
                    ForeColor = Color.FromArgb(1, 112, 184)
                };
                button.FlatAppearance.BorderColor = Color.FromArgb(1, 112, 184);
            }
            base.OnLoad(e);
        }
    }
}
