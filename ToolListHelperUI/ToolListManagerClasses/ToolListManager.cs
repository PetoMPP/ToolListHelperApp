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
    public partial class ToolListManager : Form
    {
        private static readonly Color _defaultButtonBackColor = Color.FromArgb(1, 112, 184);
        private static readonly Font _defaultButtonFont = new("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        private static readonly Color _activeButtonBackColor = Color.FromArgb(30, 165, 235);
        private static readonly Font _activeButtonFont = new("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        private Form? _activeForm;
        private readonly ToolListBasicData _basicDataForm = new();
        public ToolListManager()
        {
            InitializeComponent();
        }

        private void ModeLabel_Click(object sender, EventArgs e)
        {
            Label callingLabel = (Label)sender;
            AdjustLabels(callingLabel);
            if (callingLabel.Name == nameof(basicDataLabel))
            {
                LoadForm(_basicDataForm);
                return;
            }
            if (callingLabel.Name == nameof(toolListLabel))
            {
                return;
            }
            if (callingLabel.Name == nameof(fileManagementLabel))
            {
                return;
            }
            if (callingLabel.Name == nameof(documentsLabel))
            {
                return;
            }
        }

        private void AdjustLabels(Label callingLabel)
        {
            foreach (Label label in navigationPanel.Controls.OfType<Label>())
            {
                label.BackColor = _defaultButtonBackColor;
                label.Font = _defaultButtonFont;
            }
            callingLabel.BackColor = _activeButtonBackColor;
            callingLabel.Font = _activeButtonFont;
        }

        private void LoadForm(Form form)
        {
            _activeForm = form;
            _activeForm.TopLevel = false;
            viewPanel.Controls.Add(_activeForm);
            _activeForm.BringToFront();
            _activeForm.Show();
            _activeForm.Width = viewPanel.VerticalScroll.Visible ? viewPanel.Width - (SystemInformation.Border3DSize.Width * 2) - SystemInformation.VerticalScrollBarWidth : viewPanel.Width - (SystemInformation.Border3DSize.Width * 2);
        }

        private async void LoadListButton_Click(object sender, EventArgs e)
        {
            try
            {
                await GetListData();
            }
            catch (Exception error)
            {
                UserInterfaceLogic.ShowError(error.Message, "Błąd podczas ładowania listy!");
            }
        }

        private async Task GetListData()
        {
            string listId = listIdTextBox.Text.Trim();
            if (!await TDMConnector.ValidateListIdAsync(listId))
            {
                throw new Exception($"Brak listy o numerze ID: '{listId}' w TDM!");
            }
            ListBrowsingModel model = await ToolListManagerTdmConnector.GetListBrowsingModel(listId);
            _basicDataForm.LoadListData();
        }

        private void ToolListManager_Resize(object sender, EventArgs e)
        {
            viewPanel.Size = viewPanel.ClientRectangle.Size;
            if (_activeForm == null)
            {
                return;
            }
            _activeForm.Width = viewPanel.VerticalScroll.Visible ? viewPanel.Width - (SystemInformation.Border3DSize.Width * 2) - SystemInformation.VerticalScrollBarWidth : viewPanel.Width - (SystemInformation.Border3DSize.Width * 2);
            _activeForm.Height = viewPanel.VerticalScroll.Visible ? viewPanel.Height - (SystemInformation.Border3DSize.Width * 2) - SystemInformation.VerticalScrollBarWidth : viewPanel.Height - (SystemInformation.Border3DSize.Width * 2);
        }
    }
}
