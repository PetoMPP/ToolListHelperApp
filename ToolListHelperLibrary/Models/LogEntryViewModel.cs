using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperLibrary.Models
{
    public struct LogEntryViewModel
    {
        public int Position { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
    }
}
