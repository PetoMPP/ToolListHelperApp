using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperLibrary.Models
{
    public struct ToolData
    {
        public string Id { get; set; }
        public string ItemDescription { get; set; }
        public ToolType ToolType { get; set; }
    }
}
