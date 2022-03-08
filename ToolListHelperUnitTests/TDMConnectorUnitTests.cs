using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolListHelperLibrary;
using Xunit;

namespace ToolListHelperUnitTests
{
    public class TDMConnectorUnitTests
    {
        [Fact]
        public void GetNextIdFromString()
        {
            Assert.Equal("kamil100", TDMConnector.CreateListIdFromString("kamil99"));
            Assert.Equal("berek1", TDMConnector.CreateListIdFromString("berek"));
        }
    }
}
