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
using ToolListHelperUI.Properties;

namespace ToolListHelperUI.ToolListManagerClasses
{
    public partial class ToolListManager : Form, IThemeLoader, IBrowseData
    {
        private static readonly Color _defaultButtonBackColor = Color.FromArgb(1, 112, 184);
        private static readonly Font _defaultButtonFont = new("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        private static readonly Color _activeButtonBackColor = Color.FromArgb(30, 165, 235);
        private static readonly Font _activeButtonFont = new("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        public Form? _activeForm;
        private readonly ToolListBasicData _basicDataForm;
        private readonly ToolListList _toolListForm;
        private readonly ToolListFileManager _fileManagerForm;
        private readonly Form _caller;

        public ToolListManager(Form caller)
        {
            InitializeComponent();
            _caller = caller;
            _basicDataForm = new();
            _toolListForm = new(_caller);
            _fileManagerForm = new();
            // Opens default menu tab on startup
            ModeLabel_Click(basicDataLabel, new EventArgs());
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
            _activeForm.Width = viewPanel.Width - (SystemInformation.Border3DSize.Width * 2);
            try
            {
                ((IThemeLoader)form).LoadTheme(UserConfigManager.GetCurrentUserTheme());
            }
            catch (Exception error)
            {
                UserInterfaceLogic.ShowError(error.Message, "Błąd motywu!");
            }
        }

        private async void LoadListButton_Click(object sender, EventArgs e)
        {
            try
            {
                await LoadListData();
            }
            catch (Exception error)
            {
                UserInterfaceLogic.ShowError(error.Message, "Błąd podczas ładowania listy!");
            }
        }

        private async Task LoadListData()
        {
            string listId = listIdTextBox.Text.Trim();
            if (!await TDMConnector.ValidateListIdAsync(listId))
            {
                throw new Exception($"Brak listy o numerze ID: '{listId}' w TDM!");
            }
            ListBrowsingModel model = await ToolListManagerTdmConnector.GetListBrowsingModel(listId);
            _basicDataForm.LoadListData(model);
            _toolListForm.LoadListData(model);
            _fileManagerForm.LoadListData(model);
        }

        private void ToolListManager_Resize(object sender, EventArgs e)
        {
            viewPanel.Size = viewPanel.ClientRectangle.Size;
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
            _activeForm.Width = viewPanel.Width - (SystemInformation.Border3DSize.Width * 2);
            _activeForm.Height = viewPanel.Height - (SystemInformation.Border3DSize.Width * 2);
        }

        private static int GetLabelXCoordinate(int labelWidth, int position)
        {
            int spacingWidth = labelWidth / 4;
            return (spacingWidth + labelWidth) * position + spacingWidth / 2;
        }
        protected override void OnLoad(EventArgs e)
        {
            Button button = new()
            {
                Size = new(21, 21),
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Right,
                Cursor = Cursors.Default,
                Text = "▼",
                ForeColor = Color.FromArgb(1, 112, 184),
                Visible = false
            };
            button.FlatAppearance.BorderColor = Color.FromArgb(1, 112, 184);
            button.Font = new("Segoe UI", 9, FontStyle.Bold);
            button.Click += BrowseIdButton_Click;
            listIdTextBox.Controls.Add(button);
            listIdTextBox.Enter += TextBox_Enter;
            listIdTextBox.KeyDown += TextBox_KeyDown;
            listIdTextBox.Leave += TextBox_Leave;
            InteropOperations.SendMessage(listIdTextBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(button.Width << 16));
            base.OnLoad(e);
            LoadTheme(Enum.Parse<ApplicationTheme>(Settings.Default.ApplicationTheme));
        }
        private async void BrowseIdButton_Click(object sender, EventArgs e)
        {
            BrowseWindow browseWindow = new(this, BrowsingMode.ProgramId, this);
            browseWindow.ShowDialog();
            try
            {
                await LoadListData();
            }
            catch (Exception error)
            {
                UserInterfaceLogic.ShowError(error.Message, "Błąd ładowania listy!");
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Button button = textBox.Controls.OfType<Button>().First();
            button.Visible = true;
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Button button = textBox.Controls.OfType<Button>().First();
            button.Visible = false;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                selectedListLabel.Focus();
            }
        }

        public void LoadTheme(ApplicationTheme applicationTheme)
        {
            ApplicationThemes.ApplyTheme(this, applicationTheme, new Form[] { _basicDataForm, _toolListForm, _fileManagerForm });
            switch (applicationTheme)
            {
                case ApplicationTheme.Light:
                    createListButton.BackgroundImage = Resources._new;
                    saveListButton.BackgroundImage = Resources.edit;
                    reloadListButton.BackgroundImage = Resources.load;
                    deleteListButton.BackgroundImage= Resources.delete;
                    break;
                case ApplicationTheme.Dark:
                    createListButton.BackgroundImage = Resources.new_dark;
                    saveListButton.BackgroundImage = Resources.edit_dark;
                    reloadListButton.BackgroundImage = Resources.load_dark;
                    deleteListButton.BackgroundImage = Resources.delete_dark;
                    break;
            }
        }

        public void LoadDataToUI(string[] dataStrings, BrowsingMode browsingMode)
        {
            listIdTextBox.Text = browsingMode switch
            {
                BrowsingMode.ProgramId => dataStrings[0],
                _ => throw new InvalidOperationException(),
            };
        }

        private async void ListIdTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                await LoadListData();
            }
            catch (Exception error)
            {
                UserInterfaceLogic.ShowError(error.Message, "Błąd podczas ładowania listy!");
            }
        }

        private async void ListIdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    await LoadListData();
                }
                catch (Exception error)
                {
                    UserInterfaceLogic.ShowError(error.Message, "Błąd podczas ładowania listy!");
                }
            }
        }
    }
}
