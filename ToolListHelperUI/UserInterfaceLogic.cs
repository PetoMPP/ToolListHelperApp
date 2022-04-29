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
        public static void HandleClick(DataGridView dataGridView, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (dataGridView.HitTest(e.X, e.Y).Type != DataGridViewHitTestType.Cell)
                {
                    dataGridView.ClearSelection();
                }
                else
                {
                    dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].Selected = true;
                }
            }
        }
    }
}
