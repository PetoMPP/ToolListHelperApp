using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolListHelperLibrary.Models;

namespace ToolListHelperLibrary
{
    public static class ToolListManagerTdmConnector
    {
        public static async Task<ListBrowsingModel> GetListBrowsingModel(string listId)
        {
            using DbConnection connection = TDMConnector.GetTDMConnection();
            return await connection.QueryFirstAsync<ListBrowsingModel>(new CommandDefinition(@"
SELECT TOO MANY DATA", 
commandType: System.Data.CommandType.Text));
        }
    }
}
