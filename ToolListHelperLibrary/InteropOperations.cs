using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperLibrary
{
    public static class InteropOperations
    {
        /// <summary>
        /// This method send message with user32.dll to overwrite default behavior of controls.
        /// </summary>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
