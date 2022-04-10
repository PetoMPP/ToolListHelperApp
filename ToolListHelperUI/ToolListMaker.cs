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
    public partial class ToolListMakerWindow : Form, IBrowseData, IThemeLoader
    {
        private readonly List<Panel> _sectionPanels;
        private readonly List<RadioButton> _updateRadioButtons;
        private string? _filePathString;
        private string[] _filePaths = Array.Empty<string>();
        public ToolListMaker()
        {
            // HACK - Some programmers have issues when lists are initialized after InitializeComponent()
            _sectionPanels = new()
            {
                wizardPanel,
                createPanel,
                modePanel,
                creatingModePanel,
                programNamePanel,
                programDescriptionPanel,
                machinePanel,
                sourceFilePanel,
                listTypePanel,
                addFilePanel,
                materialPanel,
                clampingPanel
            };
            _updateRadioButtons = new()
            {
                skipNameRadioButton,
                skipProgramDescriptionRadioButton,
                skipMachineRadioButton,
                skipListTypeRadioButton,
                skipMaterialRadioButton,
                skipClampingRadioButton
            };
            InitializeComponent();
            _sectionPanels = new()
            {
                wizardPanel,
                createPanel,
                modePanel,
                creatingModePanel,
                programNamePanel,
                programDescriptionPanel,
                machinePanel,
                sourceFilePanel,
                listTypePanel,
                addFilePanel,
                materialPanel,
                clampingPanel
            };
            _updateRadioButtons = new()
            {
                skipNameRadioButton,
                skipProgramDescriptionRadioButton,
                skipMachineRadioButton,
                skipListTypeRadioButton,
                skipMaterialRadioButton,
                skipClampingRadioButton
            };
            LoadTheme(Enum.Parse<ApplicationTheme>(Properties.Settings.Default.ApplicationTheme));
        }

        private void ResizeSectionPanels()
        {
            int width = Width;
            descriptionPanel.Width = width;
            int halfWidth = width / 2;
            foreach (Panel? panel in _sectionPanels)
            {
                if (panel == null)
                {
                    continue;
                }
                ResizeSectionPanel(halfWidth, panel);
            }
        }

        private static void ResizeSectionPanel(int halfWidth, Panel panel)
        {
            panel.Width = halfWidth;
            if (panel.Location.X != 0)
            {
                panel.Location = new Point(halfWidth, panel.Location.Y);
            }
            ResizePanelControls(panel);
        }

        private static void ResizePanelControls(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                ResizePanelControl(panel, control);
            }
        }

        private static void ResizePanelControl(Panel panel, Control control)
        {
            int halfPanelWidth = panel.Width / 2;
            control.Width = halfPanelWidth;
            if (control.Location.X != 0)
            {
                control.Location = new Point(halfPanelWidth, control.Location.Y);
            }
        }

        private void ToolListMakerWindow_Shown(object sender, EventArgs e)
        {
            ResizeSectionPanels();
        }

        private void FileModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton callingRadio = (RadioButton)sender;
            if (!(machineTextBox.Text == "MMLCUBEB" ||
                machineTextBox.Text == "MCTX125A" ||
                string.IsNullOrEmpty(machineTextBox.Text)))
            {
                return;
            }
            switch (callingRadio.Name)
            {
                case "sinumericModeRadioButton":
                case "autoModeRadioButton":
                    machineTextBox.Text = string.Empty;
                    autoMachineRadioButton.Checked = true;
                    return;
                case "fusionModeRadioButton":
                    machineTextBox.Text = "MMLCUBEB";
                    selectMachineRadioButton.Checked = true;
                    break;
                case "shopturnModeRadioButton":
                    machineTextBox.Text = "MCTX125A";
                    selectMachineRadioButton.Checked = true;
                    break;
                default:
                    return;
            }
        }

        private void CreatingModeUpdateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton callingRadio = (RadioButton)sender;
            WireUpRadioButtons_CheckedChanged(sender, e);
            foreach (RadioButton radio in _updateRadioButtons)
            {
                radio.Enabled = callingRadio.Checked;
                radio.Checked = callingRadio.Checked;
            }
        }
        private void WireUpRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton callingRadio = (RadioButton)sender;
            /// Evaluate calling radio mode
            /// TabIndex 2 = manual input
            /// TabIndex 3 = skip
            Panel parentPanel = (Panel)callingRadio.Parent;
            if (callingRadio.TabIndex == 2)
            {
                WireUpInputPanel(callingRadio, parentPanel);
                return;
            }
            if (callingRadio.TabIndex == 3 && !callingRadio.Enabled)
            {
                WireUpRadioBoxes(parentPanel);
                return;
            }

        }

        private static void WireUpRadioBoxes(Panel parentPanel)
        {
            Panel? textBoxPanel = !parentPanel.Controls.OfType<Panel>().Any() ? null : parentPanel.Controls.OfType<Panel>()
                                .First().Controls
                                .OfType<Panel>()
                                .OrderBy(p => p.TabIndex)
                                .FirstOrDefault();
            if (textBoxPanel == null)
            {
                parentPanel.Controls.OfType<RadioButton>().Where(r => r.TabIndex == 1).First().Checked = true;
                return;
            }
            TextBox textBox = parentPanel.Controls.OfType<Panel>()
                                .First().Controls
                                .OfType<Panel>()
                                .OrderBy(p => p.TabIndex)
                                .First()
                                .Controls
                                .OfType<TextBox>()
                                .First();
            if (string.IsNullOrEmpty(textBox.Text))
            {
                parentPanel.Controls.OfType<RadioButton>().Where(r => r.TabIndex == 1).First().Checked = true;
                return;
            }
            parentPanel.Controls.OfType<RadioButton>().Where(r => r.TabIndex == 2).First().Checked = true;
        }

        private static void WireUpInputPanel(RadioButton callingRadio, Panel parentPanel)
        {
            if (!parentPanel.Controls.OfType<Panel>().Any())
            {
                return;
            }
            // switch textBox
            parentPanel.Controls.OfType<Panel>()
                .First().Controls
                .OfType<Panel>()
                .OrderBy(p => p.TabIndex)
                .First().Controls
                .OfType<TextBox>()
                .First().Enabled = callingRadio.Checked;
            // switch button
            parentPanel.Controls.OfType<Panel>()
                .First().Controls
                .OfType<Panel>()
                .OrderByDescending(p => p.TabIndex)
                .First().Controls
                .OfType<Button>()
                .First().Enabled = callingRadio.Checked;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            BrowsingMode browsingMode;
            switch (button.Tag)
            {
                case "ProgramId":
                    browsingMode = BrowsingMode.ProgramId;
                    break;
                case "ProgramName":
                    browsingMode = BrowsingMode.ProgramName;
                    break;
                case "ProgramDescription":
                    browsingMode = BrowsingMode.ProgramDescription;
                    break;
                case "Machine":
                    browsingMode = BrowsingMode.Machine;
                    break;
                case "Material":
                    browsingMode = BrowsingMode.Material;
                    break;
                case "Clamping":
                    browsingMode = BrowsingMode.Clamping;
                    break;
                default:
                    return;
            }
            Enabled = false;
            BrowseWindow browseWindow = new(this, browsingMode, this);
            browseWindow.ShowDialog();
        }

        public void LoadDataToUI(string dataString, BrowsingMode browsingMode)
        {
            switch (browsingMode)
            {
                case BrowsingMode.ProgramId:
                    programIdTextBox.Text = dataString;
                    break;
                case BrowsingMode.ProgramName:
                    programNameTextBox.Text = dataString;
                    break;
                case BrowsingMode.ProgramDescription:
                    programDescriptionTextBox.Text = dataString;
                    break;
                case BrowsingMode.Machine:
                    machineTextBox.Text = dataString;
                    break;
                case BrowsingMode.Material:
                    materialTextBox.Text = dataString;
                    break;
                case BrowsingMode.Clamping:
                    clampingTextBox.Text = dataString;
                    break;
            }
        }

        private async void CreateListButton_Click(object sender, EventArgs e)
        {
            string errorMessage = ValidateUI();
            if (errorMessage.Length > 0)
            {
                UserInterfaceLogic.ShowError(errorMessage, "Błąd w formularzu!");
                return;
            }
            ListModel model = await CreateModelFromUI();
            errorMessage = await ValidateModel(model);
            if (errorMessage.Length > 0)
            {
                UserInterfaceLogic.ShowError(errorMessage, "Błąd danych!");
                return;
            }
            if (string.IsNullOrEmpty(model.Machine) && !model.SkipMachine &&
                UserInterfaceLogic.ShowWarning("Nie wybrano maszyny dla listy narzędziowej, czy chcesz kontynuować?", "Brak maszyny!") == DialogResult.No)
            {
                return;
            }
            if (!model.SkipNcFile && _filePaths.Length > 1 &&
                UserInterfaceLogic.ShowWarning($"Wybrano więcej niż jeden plik źrodłowy do przesłania do TDM, program wspiera przesyłanie tylko jednego pliku naraz, przez co tylko plik: \"{Path.GetFileName(model.NcFile.FilePath)}\" zostanie przesłany.\n\nKontynuować?", "Wybrano wiele list do przesłania!") == DialogResult.No)
            {
                return;
            }
            (List<ToolData> invalidTools, List<ToolData> validTools) = await TDMConnector.ValidateToolsAsync(model.Tools);
            if (invalidTools.Count > 0)
            {
                if (UserInterfaceLogic.ShowWarning("Następujące narzędzia z pliku nie zostały odnalezione w bazie TDM:\n\n" + string.Join('\n', invalidTools.Select(t => string.IsNullOrEmpty(t.Id) ? t.ItemDescription : t.Id)
                    .ToArray()) + "\n\nCzy chcesz kontynuować tworzenie listy bez tych narzędzi?", "Brakujące narzędzia!") == DialogResult.No)
                {
                    return;
                }
            }
            model.Tools = validTools;
            (string listId, errorMessage) = await TDMConnector.PostListModelAsync(model);
            if (errorMessage.Length > 0)
            {
                UserInterfaceLogic.ShowError(errorMessage, "Błąd podczas tworzenia listy!");
                return;
            }
            Enabled = false;
            UserInterfaceLogic.ShowSuccess(listId, this);
        }
        private static async Task<string> ValidateModel(ListModel model)
        {
            string errorMessage = string.Empty;
            int errorCounter = 1;
            if (model.Tools?.Count == 0)
            {
                errorMessage += $"{errorCounter}. Plik nie zawiera żadnych narzędzi!\n\n";
                errorCounter++;
            }
            if (model.CreatingMode == CreatingMode.Update)
            {
                if (!await TDMConnector.ValidateListIdAsync(model.Id))
                {
                    errorMessage += $"{errorCounter}. Brak listy o numerze: {model.Id} w TDM!";
                    errorCounter++;
                }
            }
            if (!await TDMConnector.ValidateUserAsync(model.CreatorId))
            {
                errorMessage += $"{errorCounter}. Brak użytkownika o nazwie {model.CreatorId} w TDM!";
            }
            return errorMessage;
        }

        private string ValidateUI()
        {
            string errorMessage = string.Empty;
            int errorCounter = 1;
            // Validate Source file
            if (_filePaths.Length == 0)
            {
                errorMessage += $"{errorCounter}. Nie dodano pliku źródłowego!\n\n";
                errorCounter++;
            }
            else
            {
                (string pathErrorMessage, errorCounter) = FileOperations.ValidateProgramPaths(_filePaths, errorCounter);
                if (!string.IsNullOrEmpty(pathErrorMessage))
                {
                    errorMessage += $"{errorCounter}. " + pathErrorMessage;
                }
            }
            // Validate Controls
            List<(string name, RadioButton radioButton, TextBox textBox)> manualInputs = new()
            {
                (creatingModeLabel.Text, creatingModeUpdateRadioButton, programIdTextBox),
                (programNameLabel.Text, manualNameRadioButton, programNameTextBox),
                (programDescriptionLabel.Text, manualProgramDescriptionRadioButton, programDescriptionTextBox),
                (machineLabel.Text, selectMachineRadioButton, machineTextBox),
                (materialLabel.Text, selectMaterialRadioButton, materialTextBox),
                (clampingLabel.Text, selectClampingRadioButton, clampingTextBox)
            };
            foreach ((string name, RadioButton radioButton, TextBox textBox) in manualInputs)
            {
                if (radioButton.Checked && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    errorMessage += $"{errorCounter}. W sekcji \"{name}\" zaznaczono ręczne wprowadzenie danych i pozostawiono puste pole tekstowe!\n\n";
                    errorCounter++;
                }
            }
            if (errorMessage.Length > 0)
            {
                errorMessage = "W formularzu znajdują się następujące błędy:\n\n" + errorMessage;
            }
            return errorMessage;
        }

        private NcFileType GetFileTypeFromUI()
        {
            if (autoModeRadioButton.Checked)
            {
                return NcFileType.Auto;
            }
            if (sinumericModeRadioButton.Checked)
            {
                return NcFileType.Sinumeric;
            }
            if (fusionModeRadioButton.Checked)
            {
                return NcFileType.Fusion;
            }
            return NcFileType.ShopTurn;
        }

        private async Task<ListModel> CreateModelFromUI()
        {
            CreatingMode creatingMode = creatingModeNewRadioButton.Checked ? CreatingMode.New : CreatingMode.Update;
            string id = creatingModeNewRadioButton.Checked ? await TDMConnector.GetNextListIdAsync() : programIdTextBox.Text;
            bool skipName = skipNameRadioButton.Checked;
            string? name = skipName ? null : autoNameRadioButton.Checked ? FileOperations.GetProgramNameFromFile(_filePaths[0]) : programNameTextBox.Text;
            bool skipDescription = skipProgramDescriptionRadioButton.Checked;
            string? description = skipDescription ? null : noProgramDescriptionRadioButton.Checked ? null : programDescriptionTextBox.Text;
            bool skipMachine = skipMachineRadioButton.Checked;
            string? machine = skipMachine ? null : autoMachineRadioButton.Checked ? await FileOperations.GetMachineFromFilesAsync(_filePaths, GetFileTypeFromUI()) : machineTextBox.Text;
            bool skipListType = skipListTypeRadioButton.Checked;
            ListType? listType = skipListType ? null : primaryTypeRadioButton.Checked ? ListType.Primary : ListType.Secondary;
            bool skipMaterial = skipMaterialRadioButton.Checked;
            string? material = skipMaterial ? null : noMaterialRadioButton.Checked ? null : materialTextBox.Text;
            bool skipClamping = skipClampingRadioButton.Checked;
            string? clamping = skipClamping ? null : noClampingRadioButton.Checked ? null : clampingTextBox.Text;
            bool skipNcFile = skipAddFileRadioButton.Checked;
            NcFileData ncFile = skipNcFile ? new() {NcFileMode = NcFileMode.None} : new() { FilePath = _filePaths[0], NcFileMode = addFileAsArchiveRadioButton.Checked ? NcFileMode.Archive : addFileAsDevelopingRadioButton.Checked ? NcFileMode.Developing : NcFileMode.Release };
            List<ToolData>? tools = await FileOperations.GetToolsFromFilesAsync(_filePaths, GetFileTypeFromUI());
            string creator = Environment.UserName.ToUpper();
            ListStatus listStatus = listStatusCheckBox.Checked ? ListStatus.Ready : ListStatus.Preparing;
            return new()
            {
                CreatingMode = creatingMode,
                Id = id,
                Name = name,
                SkipName = skipName,
                Description = description,
                SkipDescription = skipDescription,
                Machine = machine,
                SkipMachine = skipMachine,
                ListType = listType,
                SkipListType = skipListType,
                Material = material,
                SkipMaterial = skipMaterial,
                Clamping = clamping,
                SkipClamping = skipClamping,
                NcFile = ncFile,
                SkipNcFile = skipNcFile,
                Tools = tools,
                CreatorId = creator,
                ListStatus = listStatus
            };
        }

        private void BrowseFilesButton_Click(object sender, EventArgs e)
        {   
            OpenFileDialog dialog = new();
            dialog.Multiselect = true;
            dialog.RestoreDirectory = true;
            switch (GetFileTypeFromUI())
            {
                case NcFileType.Sinumeric:
                    dialog.InitialDirectory = "M:/";
                    dialog.Filter = "Pliki MPF/SPF|*.mpf;*.spf|Wszystkie pliki|*.*";
                    break;
                case NcFileType.Fusion:
                    dialog.InitialDirectory = "M:/MMLCUBEB";
                    dialog.Filter = "Pliki Fusion|*.simpl|Wszystkie pliki|*.*";
                    break;
                case NcFileType.ShopTurn:
                    dialog.InitialDirectory = "M:/MCTX125A";
                    dialog.Filter = "Pliki MPF|*.mpf|Wszystkie pliki|*.*";
                    break;
                case NcFileType.Auto:
                    dialog.InitialDirectory = "M:/";
                    dialog.Filter = "Pliki kodu maszynowego|*.mpf;*.spf;*.simpl|Pliki MPF/SPF|*.mpf;*.spf|Pliki Fusion|*.simpl|Wszystkie pliki|*.*";
                    break;
            }
            dialog.ShowDialog();
            sourceFilePathTextBox.Text = _filePathString = string.Join('|', dialog.FileNames);
            if (!string.IsNullOrEmpty(_filePathString))
            {
                _filePaths = _filePathString.Split('|'); 
            }
            else
            {
                _filePaths = Array.Empty<string>();
            }
        }

        private void SourceFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            sourceFilePathTextBox.Text = _filePathString;
        }

        private void SourceFilePathTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void SourceFilePathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null)
            {
                return;
            }
            _filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            _filePathString = string.Join("|", _filePaths);
            sourceFilePathTextBox.Text = _filePathString;
        }

        private void SourceFilePathTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data == null)
            {
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        public void LoadTheme(ApplicationTheme applicationTheme)
        {
            ApplicationThemes.ApplyTheme(this, applicationTheme);
        }
    }
}
