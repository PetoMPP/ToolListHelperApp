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

namespace ToolListHelperUI
{
    public partial class DatronDictator : Form, IThemeLoader
    {
        private Dictionary<string, string> _localDict = new();
        private readonly List<Control> _quaterControls;
        private readonly List<Control> _halfControls;
        public DatronDictator()
        {
            InitializeComponent();
            _quaterControls = new()
            {
                saveChangesButtonPanel,
                deleteSelectedButtonPanel,
                reloadDictonaryButtonPanel,
                importDictonaryButtonPanel,
                programNamePanel,
                tdmNamePanel
            };
            _halfControls = new()
            {
                leftPanel,
                rightPanel,
                addNewEntryLabel,
                addNewEntryButtonPanel
            };
            LoadFileDictonary();
            LoadDataToUI();
            LoadTheme(Enum.Parse<ApplicationTheme>(Properties.Settings.Default.ApplicationTheme));
        }

        private void LoadFileDictonary()
        {
            _localDict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> keyValuePair in CsvOperations.LoadDescriptionsDictonary())
            {
                _localDict[keyValuePair.Key] = keyValuePair.Value;
            }
        }

        private void LoadDataToUI()
        {
            dictonaryDataGridView.DataSource = null;
            dictonaryDataGridView.DataSource = TableOperations.CreateTableFromListOfModels(_localDict);
            AdjustUI();
        }

        private void AdjustUI()
        {
            dictonaryDataGridView.Columns["Key"].Width = dictonaryDataGridView.Width / 2 - 4;
            dictonaryDataGridView.Columns["Value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DictonaryDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dictonaryDataGridView.SelectedRows.Count > 0)
            {
                deleteSelectedButton.Enabled = true;
                return;
            }
            deleteSelectedButton.Enabled = false;
        }

        private void ReloadDictonaryButton_Click(object sender, EventArgs e)
        {
            LoadFileDictonary();
            LoadDataToUI();
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> updatedDictonary = new();
            foreach (DataGridViewRow row in dictonaryDataGridView.Rows)
            {
                string? key = row.Cells["Key"].Value?.ToString();
                string? value = row.Cells["Value"].Value?.ToString();
                if (key == null || value == null)
                {
                    continue;
                }
                updatedDictonary.Add(key, value);
            }
            try
            {
                CsvOperations.OverwriteDictonary(updatedDictonary);
            }
            catch (FileNotFoundException error)
            {
                UserInterfaceLogic.ShowError(error.Message, "Błąd podczas zapisu!");
                return;
            }
            MessageBox.Show("Pomyślnie zapisano nowy słownik!", "Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NewEntryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(programNameTextBox.Text) || string.IsNullOrEmpty(tdmNameTextBox.Text))
            {
                addNewEntryButton.Enabled = false;
                return;
            }
            addNewEntryButton.Enabled = true;
        }

        private void AddNewEntryButton_Click(object sender, EventArgs e)
        {
            _localDict[programNameTextBox.Text] = tdmNameTextBox.Text;
            LoadDataToUI();
            programNameTextBox.Text = string.Empty;
            tdmNameTextBox.Text = string.Empty;
        }

        private void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dictonaryDataGridView.SelectedRows)
            {
                _localDict.Remove(row.Cells["Key"].Value.ToString() ?? string.Empty);
            }
            LoadDataToUI();
        }

        private void ImportDictonaryButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "Plik tekstowy|*.txt|Wszystkie pliki|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadFileAsNewDictonary(dialog.FileName);
            }
        }

        private void LoadFileAsNewDictonary(string fileName)
        {
            Dictionary<string, string> retrievedData = CsvOperations.GetDictonaryFromTextFile(fileName);
            if (retrievedData.Count == 0)
            {
                UserInterfaceLogic.ShowError("Wybrany plik nie zawiera słownika lub jest źle sformatowany!", "Błąd importu!");
                return;
            }
            switch (MessageBox.Show("Chcesz nadpisać istniejącą listę (Tak) czy dopisać do niej wpisy z pliku (Nie)?", "Wybierz tryb importu.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Cancel:
                    return;
                case DialogResult.Yes:
                    _localDict = retrievedData;
                    break;
                case DialogResult.No:
                    foreach (KeyValuePair<string, string> keyValuePair in retrievedData)
                    {
                        _localDict[keyValuePair.Key] = keyValuePair.Value;
                    }
                    break;
            }
            LoadDataToUI();
            MessageBox.Show("Pomyślnie zaimportowano słownik! Nie zapomnij zapisać zmian!", "Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DatronDictator_Resize(object sender, EventArgs e)
        {
            descriptionPanel.Width = Width;
            int halfWidth = Width / 2;
            foreach (Control control in _halfControls)
            {
                control.Width = halfWidth;
                if (control.Location.X != 0)
                {
                    control.Location = new(halfWidth, control.Location.Y);
                }
            }
            int quaterWidth = Width / 4;
            foreach (Control control in _quaterControls)
            {
                control.Width = quaterWidth;
                if (control.Location.X != 0)
                {
                    control.Location = new(quaterWidth, control.Location.Y);
                }
            }
            dictonaryDataGridView.Columns[0].Width = quaterWidth - 4;
        }
        public void LoadTheme(ApplicationTheme applicationTheme)
        {
            ApplicationThemes.ApplyTheme(this, applicationTheme);
        }
    }
}
