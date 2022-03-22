using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private readonly List<object> _initialData = new();

        public BrowseWindow(IBrowseData browseData, BrowsingMode browsingMode, Form caller)
        {
            InitializeComponent();
            _browseData = browseData;
            _mode = browsingMode;
            _caller = caller;
            _cancellationToken = _cancellationTokenSource.Token;
            statusLabel.Width = browseDataGridView.Width - SystemInformation.VerticalScrollBarWidth - 2;
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
        }

        private void AdjustUI()
        {
            (int columnCount, int columnWidth) = ResizeDataGridColumns();
            AdjustTextBoxes(columnCount, columnWidth);
        }

        private void AdjustTextBoxes(int columnCount, int columnWidth)
        {
            textBox1Panel.Width = columnWidth;
            textBox1Panel.Visible = true;
            textBox2Panel.Width = columnWidth;
            textBox2Panel.Visible = true;
            textBox2Panel.Location = new(columnWidth, textBox2Panel.Location.Y);
            textBox3Panel.Width = columnWidth;
            textBox3Panel.Visible = true;
            if (columnCount <= 2)
            {
                textBox3Panel.Visible = false;
            }
            if (columnCount <= 1)
            {
                textBox2Panel.Visible = false;
            }
        }

        private (int columnCount, int columnWidth) ResizeDataGridColumns()
        {
            int columnCount = browseDataGridView.Columns.Count;
            bool vScrollBarVisible = browseDataGridView.Controls.OfType<VScrollBar>().First().Visible;
            int columnWidth = (browseDataGridView.Width - (vScrollBarVisible ? SystemInformation.VerticalScrollBarWidth : 0)) / columnCount;
            foreach (DataGridViewColumn column in browseDataGridView.Columns)
            {
                column.Width = columnWidth;
            }
            return (columnCount, columnWidth);
        }

        private async void LoadClampingData()
        {
            try
            {
                IEnumerable<ClampingData> clampings = await TDMConnector.GetClampingsAsync(_cancellationToken);
                _initialData.AddRange(clampings.Cast<object>());
                browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(clampings);
                AdjustUI();
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
                _initialData.AddRange(materials.Cast<object>());
                browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(materials);
                AdjustUI();
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
                _initialData.AddRange(machines.Cast<object>());
                browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(machines);
                AdjustUI();
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
                _initialData.AddRange(programs.Cast<object>());
                browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(programs);
                AdjustUI();
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
            if (browseDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
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
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            FilterDataGrid();
            AdjustUI();
        }

        private void FilterDataGrid()
        {
            switch (_mode)
            {
                case BrowsingMode.Machine:
                    FilterMachineData();
                    break;
                case BrowsingMode.Material:
                    FilterMaterialData();
                    break;
                case BrowsingMode.Clamping:
                    FilterClampingData();
                    break;
                default:
                    FilterProgramData();
                    break;
            }
        }

        private void FilterProgramData()
        {
            List<ProgramData> filteredData = new();
            if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrWhiteSpace(textBox3.Text))
            {
                ReloadDataGridData(_initialData);
                return;
            }
            filteredData.AddRange(_initialData.Cast<ProgramData>()
                .Where(p => 
                Regex.IsMatch(p.Id, textBox1.Text, RegexOptions.IgnoreCase) && 
                Regex.IsMatch(p.Name, textBox2.Text, RegexOptions.IgnoreCase) && 
                Regex.IsMatch(p.Description ?? string.Empty, textBox3.Text, RegexOptions.IgnoreCase)));
            ReloadDataGridData(filteredData);
        }

        private void ReloadDataGridData<T>(List<T> filteredData)
        {
            if (typeof(T) == typeof(object))
            {
                //filteredData = _mode switch
                //{
                //    BrowsingMode.Machine => filteredData.Cast<MachineData>().ToList(),
                //    BrowsingMode.Material => filteredData.Cast<MaterialData>().ToList(),
                //    BrowsingMode.Clamping => filteredData.Cast<ClampingData>().ToList(),
                //    _ => filteredData.Cast<ProgramData>().ToList(),
                //};
                switch (_mode)
                {
                    case BrowsingMode.Machine:
                        browseDataGridView.DataSource = null;
                        browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(filteredData.Cast<MachineData>());
                        break;
                    case BrowsingMode.Material:
                        browseDataGridView.DataSource = null;
                        browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(filteredData.Cast<MaterialData>());
                        break;
                    case BrowsingMode.Clamping:
                        browseDataGridView.DataSource = null;
                        browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(filteredData.Cast<ClampingData>());
                        break;
                    default:
                        browseDataGridView.DataSource = null;
                        browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(filteredData.Cast<ProgramData>());
                        break;
                }
                return;
            }
            browseDataGridView.DataSource = null;
            browseDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(filteredData);
        }

        private void FilterClampingData()
        {
            List<ClampingData> filteredData = new();
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                ReloadDataGridData(_initialData);
                return;
            }
            filteredData.AddRange(_initialData.Cast<ClampingData>()
                .Where(p => 
                Regex.IsMatch(p.Name, textBox1.Text, RegexOptions.IgnoreCase)));
            ReloadDataGridData(filteredData);
        }

        private void FilterMaterialData()
        {
            List<MaterialData> filteredData = new();
            if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrWhiteSpace(textBox3.Text))
            {
                ReloadDataGridData(_initialData);
                return;
            }
            filteredData.AddRange(_initialData.Cast<MaterialData>()
                .Where(p => 
                Regex.IsMatch(p.Id, textBox1.Text, RegexOptions.IgnoreCase) &&
                Regex.IsMatch(p.Name, textBox2.Text, RegexOptions.IgnoreCase) &&
                Regex.IsMatch(p.ParentGroup, textBox3.Text, RegexOptions.IgnoreCase)));
            ReloadDataGridData(filteredData);
        }

        private void FilterMachineData()
        {
            List<MachineData> filteredData = new();
            if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrWhiteSpace(textBox3.Text))
            {
                ReloadDataGridData(_initialData);
                return;
            }
            filteredData.AddRange(_initialData.Cast<MachineData>()
                .Where(p =>
                Regex.IsMatch(p.Id, textBox1.Text, RegexOptions.IgnoreCase) &&
                Regex.IsMatch(p.Name, textBox2.Text, RegexOptions.IgnoreCase) &&
                Regex.IsMatch(p.ParentGroup, textBox3.Text, RegexOptions.IgnoreCase)));
            ReloadDataGridData(filteredData);
        }

        private void BrowseDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (browseDataGridView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                SendDataToCaller();
            }
        }
    }
}
