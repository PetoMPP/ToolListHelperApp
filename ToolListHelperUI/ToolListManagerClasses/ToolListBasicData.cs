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
            rightPanel.Location = new(Width / 2, rightPanel.Location.Y);
        }
    }
}
