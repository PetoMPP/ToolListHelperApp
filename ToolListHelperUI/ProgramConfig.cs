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
    public partial class ProgramConfig : Form
    {
        private readonly ISettingsPass _settingsPass;
        public ProgramConfig(ISettingsPass settingsPass)
        {
            InitializeComponent();
            WireUpComboBoxes();
            LoadDataToUI();
            _settingsPass = settingsPass;
        }

        private void LoadDataToUI()
        {
            databaseModeComboBox.SelectedItem = AppConfigManager.GetDatabaseMode();
            databaseStringTestTextBox.Text = AppConfigManager.GetDatabaseStringByMode(DatabaseMode.Test);
            databaseStringProdTextBox.Text = AppConfigManager.GetDatabaseStringByMode(DatabaseMode.Prod);
            dictonaryModeComboBox.SelectedItem = AppConfigManager.GetDictonaryMode();
            globalDictonaryPathTextBox.Text = AppConfigManager.GetDictonaryPathByMode(DictonaryMode.Global);
            localDictonaryPathTextBox.Text = AppConfigManager.GetDictonaryPathByMode(DictonaryMode.Local);
            passPhraseTextBox.Text = AppConfigManager.GetSettingsPassPhrase();
        }

        private void WireUpComboBoxes()
        {
            databaseModeComboBox.DataSource = Enum.GetNames<DatabaseMode>();
            dictonaryModeComboBox.DataSource = Enum.GetNames<DictonaryMode>();
        }

        private void ProgramConfigWindow_Resize(object sender, EventArgs e)
        {
            int quaterWidth = Width / 4;
            databaseModePanel.Width = quaterWidth;
            dictonaryModePanel.Width = quaterWidth;
            int threeQuatersWidth = quaterWidth * 3;
            databaseStringsPanel.Width = threeQuatersWidth;
            dictonaryStringsPanel.Width = threeQuatersWidth;
        }

        private void ChangeDatabaseModeButton_Click(object sender, EventArgs e)
        {
            AppConfigManager.SetDatabaseMode(Enum.Parse<DatabaseMode>(databaseModeComboBox.SelectedText));
        }

        private void ChangeDictonaryModeButton_Click(object sender, EventArgs e)
        {
            AppConfigManager.SetDictonaryMode(Enum.Parse<DictonaryMode>(dictonaryModeComboBox.SelectedText));
        }

        private void ChangeTestDatabaseStringButton_Click(object sender, EventArgs e)
        {
            AppConfigManager.SetTestDatabaseConnectionString(databaseStringTestTextBox.Text);
        }

        private void ChangeProdDatabaseStringButton_Click(object sender, EventArgs e)
        {
            AppConfigManager.SetProdDatabaseConnectionString(databaseStringProdTextBox.Text);
        }

        private void ChangeLocalDictonaryPathButton_Click(object sender, EventArgs e)
        {
            AppConfigManager.SetLocalDictonaryPath(localDictonaryPathTextBox.Text);
        }

        private void ChangeGlobalDictonaryPathButton_Click(object sender, EventArgs e)
        {
            AppConfigManager.SetGlobalDictonaryPath(globalDictonaryPathTextBox.Text);
        }

        private void SetPassPhraseButton_Click(object sender, EventArgs e)
        {
            AppConfigManager.SetSettingsPassPhrase(passPhraseTextBox.Text);
            _settingsPass.UpdatePassPhrase();
        }
    }
}
