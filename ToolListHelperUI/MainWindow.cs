﻿using System;
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
    public partial class MainWindow : Form, ILoadForm
    {
        private Form? _activeForm;
        public MainWindow()
        {
            InitializeComponent();
            Text += $" © {DateTimeOffset.Now.Year} PetoMPP";
        }

        private async void ToolListMakerButton_ClickAsync(object sender, EventArgs e)
        {
            DisableMenuButtons();
            string errorMessage = await TDMConnector.ValidateDbConnection();
            if (errorMessage.Length > 0)
            {
                UserInterfaceLogic.ShowError(errorMessage, "Błąd połączenia");
                EnableMenuButtons();
                return;
            }
            LoadForm(new ToolListMakerWindow());
            currentModuleLabel.Text = "Tool List Maker";
            EnableMenuButtons();
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
            if (_activeForm?.GetType() == form.GetType())
            {
                return;
            }
            if (_activeForm != null)
            {
                _activeForm.Close();
            }
            _activeForm = form;
            _activeForm.TopLevel = false;
            mainPanel.Controls.Add(_activeForm);
            _activeForm.BringToFront();
            _activeForm.Show();
            _activeForm.Width = mainPanel.Width;
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

        private void MainPanel_Resize(object sender, EventArgs e)
        {
            if (_activeForm != null)
            {
                _activeForm.Width = mainPanel.Width - SystemInformation.VerticalScrollBarWidth - 4;
            }
        }

        private void CloseAppButton_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
