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

        internal void LoadListData(ToolListHelperLibrary.Models.ListBrowsingModel model)
        {
            listDataGridView.DataSource = null;
            listDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(model.Tools ?? new List<ToolListHelperLibrary.Models.ToolData>());
            listDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
