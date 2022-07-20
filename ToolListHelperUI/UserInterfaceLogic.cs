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

        public static DialogResult ShowWarning(string message, string header)
        {
            return MessageBox.Show(message, header, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowQuestion(string message, string header)
        {
            return MessageBox.Show(message, header, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static IEnumerable<Control> GetAllControls<T>(Control control)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls.SelectMany(x => GetAllControls<T>(x)).Concat(controls).Where(y => y.GetType() == typeof(T));
        }

        public static IEnumerable<Control> GetAllControls(Control control)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls.SelectMany(x => GetAllControls(x)).Concat(controls);
        }
    }
}
