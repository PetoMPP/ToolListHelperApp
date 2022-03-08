using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolListHelperLibrary;
using Xunit;

namespace ToolListHelperUnitTests
{
    public class FileOperationsUnitTests
    {
        [Fact]
        public void TestSinumericRegex()
        {
            string inputData = @"
T=""T500""
T=""T500""
T=""T21""
";
            Assert.Equal("T500", FileOperations.GetToolDataSinumeric(inputData).First().Id);
            Assert.True(FileOperations.GetToolDataSinumeric(inputData).Count == 2);
        }
        [Fact]
        public void TestShopturnRegex()
        {
            string inputData = @"(""T500"", ""T154"", ""T500"", ""0000000000"")";
            Assert.Equal("T500", FileOperations.GetToolDataShopTurn(inputData).First().Id);
            Assert.Equal(2, FileOperations.GetToolDataShopTurn(inputData).Count);
        }
        [Fact]
        public void TestFusionRegex()
        {
            string inputData = "\"ArticleNr\":\"zxkfhvbnk\"";
            Assert.Equal("zxkfhvbnk", FileOperations.GetToolDataFusion(inputData).First().ItemDescription);
        }
    }
}
