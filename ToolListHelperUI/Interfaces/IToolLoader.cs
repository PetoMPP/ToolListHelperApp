using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolListHelperLibrary.Models;

namespace ToolListHelperUI.Interfaces
{
    public interface IToolLoader
    {
        public void LoadData(ToolData tool);
    }
}
