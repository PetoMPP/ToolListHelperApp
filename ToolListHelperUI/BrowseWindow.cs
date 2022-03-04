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

namespace ToolListHelperUI
{
    public partial class BrowseWindow : Form
    {
        private readonly IBrowseData _browseData;
        private readonly BrowsingMode _mode;
        private readonly Form _caller;
        public BrowseWindow(IBrowseData browseData, BrowsingMode browsingMode, Form caller)
        {
            InitializeComponent();
            _browseData = browseData;
            _mode = browsingMode;
            _caller = caller;
            LoadDataToUI();
        }

        private void LoadDataToUI()
        {
            switch (_mode)
            {
                case BrowsingMode.ProgramId:
                    LoadProgramData(ProgramDataGridLeadColumn.Id);
                    break;
                case BrowsingMode.ProgramName:
                    LoadProgramData(ProgramDataGridLeadColumn.Name);
                    break;
                case BrowsingMode.ProgramDescription:
                    LoadProgramData(ProgramDataGridLeadColumn.Description);
                    break;
                case BrowsingMode.Machine:
                    LoadMachineData();
                    break;
                case BrowsingMode.Material:
                    LoadMaterialData();
                    break;
                case BrowsingMode.Clamping:
                    LoadClampingData();
                    break;
            }
            AdjustUI();
        }

        private void AdjustUI()
        {
            int columnCount = browseDataGridView.ColumnCount;
            switch (columnCount)
            {
                case 1:
                    Width = 166;
                    break;
                case 2:
                    Width = 316;
                    break;
                case 3:
                    Width = 466;
                    break;
                default:
                    return;
            }
            foreach (DataGridViewColumn column in browseDataGridView.Columns)
            {
                column.Width = 150 - (SystemInformation.VerticalScrollBarWidth / columnCount);
            }
        }

        private async void LoadClampingData()
        {
            IEnumerable<ClampingData> clampings = await TDMConnector.GetClampings();
            browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(clampings);
        }

        private async void LoadMaterialData()
        {
            IEnumerable<MaterialData> materials = await TDMConnector.GetMaterials();
            browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(materials);
        }

        private async void LoadMachineData()
        {
            IEnumerable<MachineData> machines = await TDMConnector.GetMachines();
            browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(machines);
        }

        private async void LoadProgramData(ProgramDataGridLeadColumn id)
        {
            IEnumerable<ProgramData> programs = await TDMConnector.GetPrograms();
            browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(programs);
        }

        private void BrowseWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _caller.Enabled = true;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            SendDataToCaller();
        }

        private void SendDataToCaller()
        {
            string? output = _mode switch
            {
                BrowsingMode.ProgramId => browseDataGridView.SelectedRows[0].Cells["Id"].Value.ToString(),
                BrowsingMode.ProgramName => browseDataGridView.SelectedRows[0].Cells["Name"].Value.ToString(),
                BrowsingMode.ProgramDescription => browseDataGridView.SelectedRows[0].Cells["Description"].Value.ToString(),
                BrowsingMode.Machine => browseDataGridView.SelectedRows[0].Cells["Name"].Value.ToString(),
                BrowsingMode.Material => browseDataGridView.SelectedRows[0].Cells["Name"].Value.ToString(),
                BrowsingMode.Clamping => browseDataGridView.SelectedRows[0].Cells["Name"].Value.ToString(),
                _ => null,
            };
            if (output != null)
            {
                _browseData.LoadDataToUI(output, _mode);
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BrowseDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SendDataToCaller();
        }

        private void BrowseDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (browseDataGridView.SelectedRows.Count > 0)
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }
    }
}
