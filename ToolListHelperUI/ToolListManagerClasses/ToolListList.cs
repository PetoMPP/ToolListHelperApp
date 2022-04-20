using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolListHelperUI.Interfaces;

namespace ToolListHelperUI.ToolListManagerClasses
{
    public partial class ToolListList : Form, IThemeLoader
    {
        public ToolListList()
        {
            InitializeComponent();
        }

        public void LoadTheme(ApplicationTheme applicationTheme)
        {
            ApplicationThemes.ApplyTheme(this, applicationTheme);
        }
    }
}
