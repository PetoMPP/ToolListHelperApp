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
        public string ItemOrderCode { get; set; }
        public int? Quantity { get; set; }
        public ToolType ToolType { get; set; }
    }
}
