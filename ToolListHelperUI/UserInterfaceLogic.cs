using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperUI
{
    public class UserInterfaceLogic
    {
        public static void ShowError(string message, string header)
        {
            MessageBox.Show(message, header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccess(string listId, Form caller)
        {
            SuccessPrompt successPrompt = new(listId, caller);
            successPrompt.ShowDialog();
        }

        internal static DialogResult ShowWarning(string message, string header)
        {
            return MessageBox.Show(message, header, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }
}
