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
    public partial class ToolListList : Form, IThemeLoader, IToolLoader
    {
        private List<ToolData> _data = new();
        private readonly Form _caller;

        public ToolListList(Form caller)
        {
            InitializeComponent();
            _caller = caller;
        }

        public void LoadTheme(ApplicationTheme applicationTheme)
        {
            ApplicationThemes.ApplyTheme(this, applicationTheme);
        }

        internal void LoadListData(ListBrowsingModel model)
        {
            _data = model.Tools ?? new List<ToolData>();
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            listDataGridView.DataSource = null;
            listDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(_data);
            listDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            listDataGridView.Columns["ItemDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DeleteToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<ToolData> toolData = _data;
            foreach (DataGridViewRow row in listDataGridView.SelectedRows)
            {
                toolData = toolData.Where(d => d.ToolListPosition != int.Parse(row.Cells[nameof(ToolData.ToolListPosition)]?.Value?.ToString() ?? "-1"));
            }
            _data = toolData.ToList();
            RefreshDataGrid();
        }

        private void AddToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewTool();
        }

        private void AddNewTool()
        {
            int nextPosition = _data.Count switch
            {
                0 => 1,
                _ => _data.Select(t => t.ToolListPosition).Max() + 1
            };
            ToolPicker toolPicker = new(this, _caller, new() { ToolListPosition = nextPosition });
            toolPicker.Show();
        }

        private void AddMultipleToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FixPositionNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                _data[i] = new() 
                { 
                    Id = _data[i].Id, 
                    ItemDescription = _data[i].ItemDescription, 
                    ItemOrderCode = _data[i].ItemOrderCode, 
                    Quantity = _data[i].Quantity, 
                    ToolType = _data[i].ToolType,
                    ToolListPosition = i + 1
                };
            }
            RefreshDataGrid();
        }

        private void ListDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            UserInterfaceLogic.HandleClick(listDataGridView, e);
        }

        public void LoadData(ToolData tool)
        {
            if (_data.Any(t => t.ToolListPosition == tool.ToolListPosition))
            {
                _data.RemoveAll(t => t.ToolListPosition == tool.ToolListPosition);
            }
            _data.Add(tool);
            _data = _data.OrderBy(t => t.ToolListPosition).ToList();
            RefreshDataGrid();
        }

        private void EditToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listDataGridView.SelectedRows.Count > 0)
            {
                EditTool();
            }
        }

        private void EditTool()
        {
            DataGridViewRow row = listDataGridView.SelectedRows[0];
            ToolData tool = new()
            {
                Id = row.Cells["Id"].Value.ToString() ?? string.Empty,
                ItemDescription = row.Cells["ItemDescription"].Value.ToString() ?? string.Empty,
                ItemOrderCode = row.Cells["ItemOrderCode"].Value.ToString() ?? string.Empty,
                ToolListPosition = int.Parse(row.Cells["ToolListPosition"].Value.ToString() ?? "-1"),
                Quantity = int.Parse(row.Cells["Quantity"].Value.ToString() ?? "-1"),
                ToolType = Enum.Parse<ToolType>(row.Cells["ToolType"].Value.ToString() ?? "Assembly")
            };
            ToolPicker toolPicker = new(this, _caller, tool);
            toolPicker.Show();
        }

        private void ListDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listDataGridView.SelectedRows.Count > 0)
            {
                EditTool();
            }
            else
            {
                AddNewTool();
            }
        }
    }
}
