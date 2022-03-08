using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private readonly string loadingErrorMessage = "Błąd ładowania danych!";
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private readonly CancellationToken _cancellationToken;

        public BrowseWindow(IBrowseData browseData, BrowsingMode browsingMode, Form caller)
        {
            InitializeComponent();
            _browseData = browseData;
            _mode = browsingMode;
            _caller = caller;
            _cancellationToken = _cancellationTokenSource.Token;
            LoadDataToUI();
        }

        private void LoadDataToUI()
        {
            switch (_mode)
            {
                case BrowsingMode.Machine:
                    LoadMachineData();
                    break;
                case BrowsingMode.Material:
                    LoadMaterialData();
                    break;
                case BrowsingMode.Clamping:
                    LoadClampingData();
                    break;
                default:
                    LoadProgramData();
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
                    statusLabel.Width = 148 - SystemInformation.VerticalScrollBarWidth;
                    break;
                case 2:
                    Width = 316;
                    statusLabel.Width = 298 - SystemInformation.VerticalScrollBarWidth;
                    break;
                case 3:
                    Width = 466;
                    statusLabel.Width = 448 - SystemInformation.VerticalScrollBarWidth;
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
            try
            {
                IEnumerable<ClampingData> clampings = await TDMConnector.GetClampingsAsync(_cancellationToken);
                browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(clampings);
            }
            catch (Exception error)
            {
                if (error.GetType() == typeof(SqlException))
                {
                    ConnectionError(error.Message);
                    return;
                }
                else if (error.GetType() == typeof(TaskCanceledException))
                {
                    return;
                }
                throw new NotSupportedException(error.Message);
            }
            statusLabel.Visible = false;
        }

        private void ConnectionError(string errorMessage)
        {
            statusLabel.Text = loadingErrorMessage;
            statusLabel.ForeColor = Color.Red;
            UserInterfaceLogic.ShowError(errorMessage, loadingErrorMessage);
        }

        private async void LoadMaterialData()
        {
            try
            {
                IEnumerable<MaterialData> materials = await TDMConnector.GetMaterialsAsync(_cancellationToken);
                browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(materials);
            }
            catch (Exception error)
            {
                if (error.GetType() == typeof(SqlException))
                {
                    ConnectionError(error.Message);
                    return;
                }
                else if (error.GetType() == typeof(TaskCanceledException))
                {
                    return;
                }
                throw new NotSupportedException(error.Message);
            }
            statusLabel.Visible = false;
        }

        private async void LoadMachineData()
        {
            try
            {
                IEnumerable<MachineData> machines = await TDMConnector.GetMachinesAsync(_cancellationToken);
                browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(machines);
            }
            catch (Exception error)
            {
                if (error.GetType() == typeof(SqlException))
                {
                    ConnectionError(error.Message);
                    return;
                }
                else if (error.GetType() == typeof(TaskCanceledException))
                {
                    return;
                }
                throw new NotSupportedException(error.Message);
            }
            statusLabel.Visible = false;
        }

        private async void LoadProgramData()
        {
            try
            {
                IEnumerable<ProgramData> programs = await TDMConnector.GetProgramsAsync(_cancellationToken);
                browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(programs);
            }
            catch (Exception error)
            {
                if (error.GetType() == typeof(SqlException))
                {
                    ConnectionError(error.Message);
                    return;
                }
                else if (error.GetType() == typeof(TaskCanceledException))
                {
                    return;
                }
                throw new NotSupportedException(error.Message);
            }
            statusLabel.Visible = false;
        }

        private void BrowseWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cancellationTokenSource.Cancel();
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
