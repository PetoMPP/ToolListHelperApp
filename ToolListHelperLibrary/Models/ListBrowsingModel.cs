using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperLibrary.Models
{
    public class ListBrowsingModel: ListModel
    {
        public string Drawing { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public string Status1 { get; set; } = string.Empty;
        public string Status2 { get; set; } = string.Empty;
        public string WorkpieceClass { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public List<NcFileData> NcFiles { get; set; } = new();
        public List<LogEntry> LogEntries { get; set; } = new();
    }
}
