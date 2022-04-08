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
    public partial class ToolListFileManager : Form
    {
        public ToolListFileManager()
        {
            InitializeComponent();
        }

        private void ToolListFileManager_Resize(object sender, EventArgs e)
        {
            foreach (Panel panel in topPanel.Controls.OfType<Panel>())
            {
                panel.Width = Width / 2;
            }
            foreach (Panel panel in bottomPanel.Controls.OfType<Panel>())
            {
                panel.Width = Width / 2;
            }
        }
    }
}
