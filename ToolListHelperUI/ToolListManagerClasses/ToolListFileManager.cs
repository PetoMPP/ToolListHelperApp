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
using ToolListHelperUI.Properties;

namespace ToolListHelperUI.ToolListManagerClasses
{
    public partial class ToolListFileManager : Form, IThemeLoader
    {
        public ToolListFileManager()
        {
            InitializeComponent();
        }

        public void LoadTheme(ApplicationTheme applicationTheme)
        {
            ApplicationThemes.ApplyTheme(this, applicationTheme);
            switch (applicationTheme)
            {
                case ApplicationTheme.Light:
                    developmentPictureBox.Image = Resources.engineering;
                    releasedPictureBox.Image = Resources.work_list;
                    archivePictureBox.Image = Resources.bookcase;
                    break;
                case ApplicationTheme.Dark:
                    developmentPictureBox.Image = Resources.engineering_dark;
                    releasedPictureBox.Image = Resources.work_list_dark;
                    archivePictureBox.Image = Resources.bookcase_dark;
                    break;
            }
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

        internal void LoadListData(ListBrowsingModel model)
        {
            developingDataGridView.DataSource = null;
            archiveDataGridView.DataSource = null;
            releasedDataGridView.DataSource = null;
            developingDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(model.NcProgramFiles.Where(f => f.StateId == "NC DEVELOPING"));
            archiveDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(model.NcProgramFiles.Where(f => f.StateId == "ARCHIVE"));
            releasedDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(model.NcProgramFiles.Where(f => f.StateId == "RELEASE FOR PRODUCTION"));
        }
    }
}
