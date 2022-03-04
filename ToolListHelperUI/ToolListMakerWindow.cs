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
    public partial class ToolListMakerWindow : Form, IBrowseData
    {
        private readonly List<Panel> _sectionPanels;
        private readonly List<RadioButton> _updateRadioButtons;
        public ToolListMakerWindow()
        {
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
        }

        private void ToolListMakerWindow_Resize(object sender, EventArgs e)
        {
            // Only horizontal adjustments
            ResizeSectionPanels();
        }

        private void ResizeSectionPanels()
        {
            int width = Width;
            descriptionPanel.Width = width;
            int halfWidth = width / 2;
            foreach (Panel panel in _sectionPanels)
            {
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
            BrowseWindow browseWindow = new(this, browsingMode, this);
            browseWindow.ShowDialog();
            Enabled = false;
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
            string filePath = sourceFilePathTextBox.Text;
            ListModel model = await CreateModelFromUI(filePath);
            (string listId, string errorMessage) = await TDMConnector.PostListModel(model);
            if (errorMessage != null)
            {
                UserInterfaceLogic.ShowError(errorMessage, "Błąd podczas tworzenia listy!");
                return;
            }
            Enabled = false;
            UserInterfaceLogic.ShowSuccess(listId, this);
        }

        private NcFileType GetFileModeFromUI(string filePath)
        {
            if (autoModeRadioButton.Checked)
            {
                return FileOperations.GetFileTypeFromFile(filePath);
            }
            if (sinumericModeRadioButton.Checked)
            {
                return NcFileType.Sinumeric;
            }
            if (fusionModeRadioButton.Checked)
            {
                return NcFileType.Fusion;
            }
            if (shopturnModeRadioButton.Checked)
            {
                return NcFileType.ShopTurn;
            }
            throw new Exception("No file type has been selected!");
        }

        private async Task<ListModel> CreateModelFromUI(string filePath)
        {
            string? id = creatingModeNewRadioButton.Checked ? await TDMConnector.GetNextListId() : programIdTextBox.Text;
            bool skipName = skipNameRadioButton.Checked;
            string? name = skipName ? null : autoNameRadioButton.Checked ? FileOperations.GetProgramNameFromFile(filePath) : programNameTextBox.Text;
            bool skipDescription = skipProgramDescriptionRadioButton.Checked;
            string? description = skipDescription ? null : noProgramDescriptionRadioButton.Checked ? null : programDescriptionTextBox.Text;
            bool skipMachine = skipMachineRadioButton.Checked;
            string? machine = skipMachine ? null : noMachineRadioButton.Checked ? null : machineTextBox.Text;
            bool skipListType = skipListTypeRadioButton.Checked;
            ListType? listType = skipListType ? null : primaryTypeRadioButton.Checked ? ListType.Primary : ListType.Secondary;
            bool skipMaterial = skipMaterialRadioButton.Checked;
            string? material = skipMaterial ? null : noMaterialRadioButton.Checked ? null : materialTextBox.Text;
            bool skipClamping = skipClampingRadioButton.Checked;
            string? clamping = skipClamping ? null : noClampingRadioButton.Checked ? null : clampingTextBox.Text;
            bool skipNcFile = skipAddFileRadioButton.Checked;
            NcFileData? ncFile = skipNcFile ? null : new() { FilePath = filePath, NcFileMode = addFileAsArchiveRadioButton.Checked ? NcFileMode.Archive : addFileAsDevelopingRadioButton.Checked ? NcFileMode.Developing : NcFileMode.Release };
            List<ToolData>? tools = FileOperations.GetToolsFromFile(filePath, GetFileModeFromUI(filePath));
            return new()
            {
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
                Tools = tools
            };
        }
    }
}
