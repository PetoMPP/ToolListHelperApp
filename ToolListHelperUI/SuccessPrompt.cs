using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolListHelperUI
{
    public partial class SuccessPrompt : Form
    {
        private readonly string _text;
        private readonly Form _caller;
        public SuccessPrompt(string listId, Form caller)
        {
            InitializeComponent();
            _text = listId;
            idTextBox.Text = _text;
            _caller = caller;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IdTextBox_TextChanged(object sender, EventArgs e)
        {
            idTextBox.Text = _text;
        }

        private void CopyToClipBoardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_text);
        }

        private void SuccessPrompt_FormClosed(object sender, FormClosedEventArgs e)
        {
            _caller.Enabled = true;
        }
    }
}
