using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolListHelperLibrary;
using ToolListHelperUI.Interfaces;
using Microsoft.Office.Interop.Outlook;

namespace ToolListHelperUI
{
    public partial class MainWindow : Form, ILoadForm, ISettingsPass
    {
        private Form? _activeForm;
        private int _settingsCounter = 0;
        private string _settingPassPhrase = AppConfigManager.GetSettingsPassPhrase();
        public MainWindow()
        {
            InitializeComponent();
            Text += $" © {DateTimeOffset.Now.Year} PetoMPP";
        }

        private async void ToolListMakerButton_ClickAsync(object sender, EventArgs e)
        {
            if (_activeForm?.GetType() == typeof(ToolListMakerWindow))
            {
                return;
            }
            DisableMenuButtons();
            string errorMessage = await TDMConnector.ValidateDbConnectionAsync();
            if (errorMessage.Length > 0)
            {
                UserInterfaceLogic.ShowError(errorMessage, "Błąd połączenia");
                EnableMenuButtons();
                return;
            }
            LoadFormToUI(new ToolListMakerWindow(), "Tool List Maker");
            EnableMenuButtons();
        }

        private void LoadFormToUI(Form form, string moduleName)
        {
            LoadForm(form);
            currentModuleLabel.Text = moduleName;
        }

        private void EnableMenuButtons()
        {
            foreach (Button button in menuPanel.Controls.OfType<Button>())
            {
                button.Enabled = true;
            }
        }

        private void DisableMenuButtons()
        {
            foreach (Button button in menuPanel.Controls.OfType<Button>())
            {
                button.Enabled = false;
            }
        }

        public void LoadForm(Form form)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }
            _activeForm = form;
            _activeForm.TopLevel = false;
            mainPanel.Controls.Add(_activeForm);
            _activeForm.BringToFront();
            _activeForm.Show();
            _activeForm.Width = mainPanel.VerticalScroll.Visible ? mainPanel.Width - (SystemInformation.Border3DSize.Width * 2) - SystemInformation.VerticalScrollBarWidth : mainPanel.Width - (SystemInformation.Border3DSize.Width * 2);
            closeAppButton.Visible = true;
        }

        public void CloseForm()
        {
            if (_activeForm != null)
            {
                _activeForm.Dispose();
                _activeForm = null;
            }
            currentModuleLabel.Text = "Uruchom aplikację korzystając z menu po lewej";
            closeAppButton.Visible = false;
        }

        private void CloseAppButton_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void ToolListMakerButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                LoadFormToUI(new ToolListMakerWindow(), "Tool List Maker");
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            mainPanel.Size = mainPanel.ClientRectangle.Size;
            if (_activeForm == null)
            {
                return;
            }
            if (_activeForm.GetType() == typeof(ToolListMakerWindow))
            {
                _activeForm.Width = mainPanel.VerticalScroll.Visible ? mainPanel.Width - (SystemInformation.Border3DSize.Width * 2) - SystemInformation.VerticalScrollBarWidth : mainPanel.Width - (SystemInformation.Border3DSize.Width * 2);
            }
            else
            {
                _activeForm.Width = mainPanel.VerticalScroll.Visible ? mainPanel.Width - (SystemInformation.Border3DSize.Width * 2) - SystemInformation.VerticalScrollBarWidth : mainPanel.Width - (SystemInformation.Border3DSize.Width * 2);
                _activeForm.Height = mainPanel.VerticalScroll.Visible ? mainPanel.Height - (SystemInformation.Border3DSize.Width * 2) - SystemInformation.VerticalScrollBarWidth : mainPanel.Height - (SystemInformation.Border3DSize.Width * 2);
            }
        }

        private void DatronDictatorButton_Click(object sender, EventArgs e)
        {
            if (_activeForm?.GetType() == typeof(DatronDictator))
            {
                return;
            }
            LoadFormToUI(new DatronDictator(), "Datron Dictator");
        }

        private async void ToolListRemoverButton_Click(object sender, EventArgs e)
        {
            if (_activeForm?.GetType() == typeof(ToolListRemover))
            {
                return;
            }
            DisableMenuButtons();
            string errorMessage = await TDMConnector.ValidateDbConnectionAsync();
            if (errorMessage.Length > 0)
            {
                UserInterfaceLogic.ShowError(errorMessage, "Błąd połączenia");
                EnableMenuButtons();
                return;
            }
            EnableMenuButtons();
            LoadFormToUI(new ToolListRemover(), "Tool List Remover");
        }

        private async void ReportIssueButton_Click(object sender, EventArgs e)
        {
            Type? officeType = Type.GetTypeFromProgID("Outlook.Application");
            if (officeType == null)
            {
                await SendEmailDefaultAsync();
                return;
            }
            reportIssueButton.Enabled = false;
            await SendEmailOutlookAsync();
        }

        private async Task SendEmailOutlookAsync()
        {
            await Task.Run(() =>
            {
                Microsoft.Office.Interop.Outlook.Application? outlook = new();
                MailItem mailItem = (MailItem)outlook.CreateItem(OlItemType.olMailItem);
                mailItem.Subject = "Tool List Maker Issue";
                mailItem.To = "pietrzyk.p@axito.pl";
                mailItem.Body = "Witam\n\nNapotkałem następujące problemy:\n";
                mailItem.Display(true);
                reportIssueButton.Invoke(() => reportIssueButton.Enabled = true);
            });
        }

        private static async Task SendEmailDefaultAsync()
        {
            Process process = new();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C start mailto:pietrzyk.p@axito.pl?subject=Tool List Maker Issue&body=Witam\n\nNapotkałem następujące problemy:\n";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            await Task.Run(() => process.Start());
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (_activeForm != null)
            {
                _settingsCounter = 0;
                return;
            }
            if (e.KeyData.ToString() == _settingPassPhrase[_settingsCounter].ToString().ToUpper())
            {
                _settingsCounter++;
            }
            else
            {
                _settingsCounter = 0;
            }
            if (_settingsCounter == _settingPassPhrase.Length)
            {
                LoadFormToUI(new ProgramConfigWindow(this), "Konfiguracja programu");
                _settingsCounter = 0;
            }
        }

        public void UpdatePassPhrase()
        {
            _settingPassPhrase = AppConfigManager.GetSettingsPassPhrase();
        }
    }
}
