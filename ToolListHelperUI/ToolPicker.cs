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
    public partial class ToolPicker : Form, IBrowseData
    {
        private readonly Form _form;
        public IToolLoader _toolLoader { get; }

        public ToolPicker(IToolLoader toolLoader, Form form, ToolData initialTool)
        {
            InitializeComponent();
            _toolLoader = toolLoader;
            _form = form;
            _form.Enabled = false;
            toolRadioButton.Enabled = true;
            LoadDataToUI(initialTool);
        }
        protected override void OnLoad(EventArgs e)
        {
            foreach (TextBox textBox in new List<TextBox>() { toolIdTextBox, toolDescriptionTextBox, toolOrderCodeTextBox})
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
                //button.Click += (object sender, EventArgs e) => { MessageBox.Show("sss"); textBox.Focus(); } ;
                button.Click += Button_Click;
                textBox.Controls.Add(button);
                textBox.Enter += TextBox_Enter;
                textBox.Leave += TextBox_Leave;
                InteropOperations.SendMessage(textBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(button.Width << 16));
            }
            base.OnLoad(e);
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Control caller = (Control)sender;
            BrowsingMode mode = compRadioButton.Checked ? BrowsingMode.ItemTriple : BrowsingMode.ToolTriple;
            BrowseWindow browseWindow = new(this, mode, this);
            browseWindow.Show();
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

        private void LoadDataToUI(ToolData initialTool)
        {
            switch (initialTool.ToolType)
            {
                case ToolType.Item:
                    compRadioButton.Checked = true;
                    break;
                case ToolType.Assembly:
                    toolRadioButton.Checked = true;
                    break;
            }
            toolIdTextBox.Text = initialTool.Id;
            toolDescriptionTextBox.Text = initialTool.ItemDescription;
            toolOrderCodeTextBox.Text = initialTool.ItemOrderCode;
            string position = initialTool.ToolListPosition.ToString();
            toolPositionTextBox.Text = string.IsNullOrEmpty(position) ? "1" : position;
            string? quantity = initialTool.Quantity.ToString();
            toolQuantityTextBox.Text = string.IsNullOrEmpty(quantity) ? "1" : quantity;
        }

        private void NumericTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case >= 48 and <= 57:
                case >= 96 and <= 105:
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                await AddTool();
                Close();
            }
            catch (Exception error)
            {
                UserInterfaceLogic.ShowError(error.Message, "Błąd!");
            }
        }

        private async Task AddTool()
        {
            ToolData tool = CreateToolFromUI();
            if (await TDMConnector.ValidateToolAsync(tool))
            {
                _toolLoader.LoadData(tool);
                return;
            }
            throw new InvalidOperationException("Invalid tool");
        }

        private ToolData CreateToolFromUI()
        {
            return new()
            {
                Id = toolIdTextBox.Text,
                ItemDescription = toolDescriptionTextBox.Text,
                ItemOrderCode = toolOrderCodeTextBox.Text,
                ToolListPosition = int.Parse(toolPositionTextBox.Text),
                Quantity = int.Parse(toolQuantityTextBox.Text),
                ToolType = compRadioButton.Checked ? ToolType.Item : ToolType.Assembly
            };
        }

        private void ToolPicker_FormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Enabled = true;
        }

        private async void ApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                await AddTool();
                AdvanceUI();
            }
            catch (Exception error)
            {
                UserInterfaceLogic.ShowError(error.Message, "Błąd!");
            }
        }

        private void AdvanceUI()
        {
            toolIdTextBox.Text = string.Empty;
            toolDescriptionTextBox.Text = string.Empty;
            toolOrderCodeTextBox.Text = string.Empty;
            toolPositionTextBox.Text = (int.Parse(toolPositionTextBox.Text) + 1).ToString();
            toolQuantityTextBox.Text = "1";
        }

        private void CompRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (compRadioButton.Checked)
            {
                SetUIState(ToolType.Item);
            }
            else
            {
                SetUIState(ToolType.Assembly);
            }
        }

        private void SetUIState(ToolType type)
        {
            switch (type)
            {
                case ToolType.Item:
                    idLabel.Text = "Id komponentu:";
                    descriptionLabel.Text = "Opis komponentu:";
                    orderCodeLabel.Text = "Nr seryjny komponentu";
                    break;
                case ToolType.Assembly:
                    idLabel.Text = "Id złożenia:";
                    descriptionLabel.Text = "Opis złożenia:";
                    orderCodeLabel.Text = "Nr seryjny złożenia";
                    break;
            }
        }

        public void LoadDataToUI(string[] dataStrings, BrowsingMode browsingMode)
        {
            toolIdTextBox.Text = dataStrings[0];
            toolDescriptionTextBox.Text = dataStrings[1];
            toolOrderCodeTextBox.Text = dataStrings[2];
        }
    }
}
