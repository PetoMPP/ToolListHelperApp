using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperLibrary.Models
{
    public struct ListModel
    {
        public CreatingMode CreatingMode { get; set; }
        public string Id { get; set; }
        public string? Name { get; set; }
        public bool SkipName { get; set; }
        public string? Description { get; set; }
        public bool SkipDescription { get; set; }
        public string? Machine { get; set; }
        public bool SkipMachine { get; set; }
        public ListType? ListType { get; set; }
        public bool SkipListType { get; set; }
        public string? Material { get; set; }
        public bool SkipMaterial { get; set; }
        public string? Clamping { get; set; }
        public bool SkipClamping { get; set; }
        public NcFileData? NcFile { get; set; }
        public bool SkipNcFile { get; set; }
        public List<ToolData>? Tools { get; set; }
    }
}
