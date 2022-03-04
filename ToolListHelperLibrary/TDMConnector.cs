using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolListHelperLibrary.Models;
using Dapper;

namespace ToolListHelperLibrary
{
    public class TDMConnector
    {
        private static DbConnection GetTDMConnection(int timeout = 15)
        {
            return new SqlConnection(AppConfigManager.GetConnectionString(timeout));
        }
        public async static Task<string> ValidateDbConnection()
        {
            using DbConnection connection = GetTDMConnection(1);
            try
            {
                await connection.OpenAsync();
            }
            catch (Exception err)
            {
                return err.Message;
            }
            return string.Empty;
        }

        public static Task<(string listId, string errorMessage)> PostListModel(ListModel model)
        {
            throw new NotImplementedException();
        }

        public static async Task<IEnumerable<ProgramData>> GetPrograms()
        {
            using DbConnection connection = GetTDMConnection();
            return await connection.QueryAsync<ProgramData>("SELECT LISTID AS Id, NCPROGRAM AS Name, PARTNAME AS Description FROM TDM_LIST", commandType: CommandType.Text);
        }

        public static async Task<IEnumerable<ClampingData>> GetClampings()
        {
            throw new NotImplementedException();
        }

        public static async Task<IEnumerable<MaterialData>> GetMaterials()
        {
            throw new NotImplementedException();
        }

        public static async Task<IEnumerable<MachineData>> GetMachines()
        {
            throw new NotImplementedException();
        }

        public static Task<string> GetNextListId()
        {
            throw new NotImplementedException();
        }
    }
}
