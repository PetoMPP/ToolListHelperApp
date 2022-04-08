using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperLibrary.Models
{
    internal struct ToolBrowsingModel
    {
        public ToolData Tool { get; set; }
        public bool IsStandard { get; set; }
        public int Quantity { get; set; }
        public string? DxfPath { get; set; }
        public string? StepPath { get; set; }
        public string? StlPath { get; set; }
        public string? Pdf2DPath { get; set; }
    }
}
