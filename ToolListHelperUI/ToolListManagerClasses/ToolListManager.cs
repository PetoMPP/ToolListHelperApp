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
        private readonly ToolListList _toolListForm = new();
        private readonly ToolListFileManager _fileManagerForm = new();
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
                LoadForm(_toolListForm);
                return;
            }
            if (callingLabel.Name == nameof(fileManagementLabel))
            {
                LoadForm(_fileManagerForm);
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
            viewPanel.Controls.Clear();
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
            ResizeActionButtons();
            int labelWidth = Width / 5;
            basicDataLabel.Width = labelWidth;
            basicDataLabel.Location = new(GetLabelXCoordinate(labelWidth, 0), basicDataLabel.Location.Y);
            toolListLabel.Width = labelWidth;
            toolListLabel.Location = new(GetLabelXCoordinate(labelWidth, 1), toolListLabel.Location.Y);
            fileManagementLabel.Width = labelWidth;
            fileManagementLabel.Location = new(GetLabelXCoordinate(labelWidth, 2), fileManagementLabel.Location.Y);
            documentsLabel.Width = labelWidth;
            documentsLabel.Location = new(GetLabelXCoordinate(labelWidth, 3), documentsLabel.Location.Y);
            if (_activeForm == null)
            {
                return;
            }
            _activeForm.Width = viewPanel.VerticalScroll.Visible ? viewPanel.Width - (SystemInformation.Border3DSize.Width * 2) - SystemInformation.VerticalScrollBarWidth : viewPanel.Width - (SystemInformation.Border3DSize.Width * 2);
            _activeForm.Height = viewPanel.VerticalScroll.Visible ? viewPanel.Height - (SystemInformation.Border3DSize.Width * 2) - SystemInformation.VerticalScrollBarWidth : viewPanel.Height - (SystemInformation.Border3DSize.Width * 2);
        }

        private static int GetLabelXCoordinate(int labelWidth, int position)
        {
            int spacingWidth = labelWidth / 4;
            return (spacingWidth + labelWidth) * position + spacingWidth / 2;
        }

        private void ResizeActionButtons()
        {
            selectedListLabel.Width = Width / 3;
            int buttonWidth = (buttonsPanel.Width - 10 - buttonsPanel.Padding.Right - buttonsPanel.Padding.Left) / 3;
            saveListButton.Width = buttonWidth;
            loadListButton.Width = buttonWidth;
            deleteListButton.Width = buttonWidth;
        }
    }
}
