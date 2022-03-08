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
        public async static Task<string> ValidateDbConnectionAsync()
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

        public async static Task<(string listId, string errorMessage)> PostListModelAsync(ListModel model)
        {
            using DbConnection connection = GetTDMConnection();
            return model.CreatingMode switch
            {
                CreatingMode.New => await CreateNewListAsync(model, connection),
                CreatingMode.Update => await UpdateListAsync(model, connection),
                _ => throw new ArgumentException("Invalid Creating Mode", nameof(model)),
            };
        }

        private async static Task<(string listId, string errorMessage)> UpdateListAsync(ListModel model, DbConnection connection)
        {
            // Change List Data
            await connection.ExecuteAsync(new CommandDefinition(await GenerateUpdateStringFromModelAsync(model, connection), commandType: CommandType.Text));
            // Overwrite Tool List
            // Insert Logfile
        }

        private async static Task<string> GenerateUpdateStringFromModelAsync(ListModel model, DbConnection connection)
        {
            StringBuilder stringBuilder = new("UPDATE TDM_LIST SET ");
            if (!model.SkipName)
            {
                if (model.Name != null)
                {
                    stringBuilder.Append($"NCPROGRAM = '{model.Name}',"); 
                }
                else
                {
                    stringBuilder.Append("NCPROGRAM = NULL,");
                }
            }
            if (!model.SkipDescription)
            {
                if (model.Description != null)
                {
                    stringBuilder.Append($"PARTNAME = '{model.Description}',");
                }
                else
                {
                    stringBuilder.Append("PARTNAME = NULL,");
                }
            }
            if (!model.SkipMachine)
            {
                if (model.Machine != null)
                {
                    stringBuilder.Append($"MACHINEID = '{model.Machine}', MACHINEGROUPID = '{await GetMachineGroupIdByMachineIdAsync(model.Machine, connection)}',");
                }
                else
                {
                    stringBuilder.Append("MACHINEID = NULL, MACHINEGROUPID = NULL,");
                }
            }
            if (!model.SkipMaterial)
            {

            }
            return stringBuilder.ToString();
        }

        private async static Task<string> GetMachineGroupIdByMachineIdAsync(string machine, DbConnection connection)
        {
            return await connection.ExecuteScalarAsync<string>($"SELECT MACHINEGROUPID FROM TDM_MACHINE WHERE MACHINEID = '{machine}'");
        }

        private static Task<(string listId, string errorMessage)> CreateNewListAsync(ListModel model, DbConnection connection)
        {
            throw new NotImplementedException();
        }

        public static async Task<IEnumerable<ProgramData>> GetProgramsAsync(CancellationToken cancellationToken)
        {
            using DbConnection connection = GetTDMConnection();
            return await connection.QueryAsync<ProgramData>(new CommandDefinition("SELECT LISTID AS Id, NCPROGRAM AS Name, PARTNAME AS Description FROM TDM_LIST", commandType: CommandType.Text, cancellationToken: cancellationToken));
        }

        public static async Task<IEnumerable<ClampingData>> GetClampingsAsync(CancellationToken cancellationToken)
        {
            using DbConnection connection = GetTDMConnection();
            return await connection.QueryAsync<ClampingData>(new CommandDefinition("SELECT DISTINCT(FIXTURE) AS Name FROM TDM_LIST", commandType: CommandType.Text, cancellationToken: cancellationToken));
        }

        public static async Task<IEnumerable<MaterialData>> GetMaterialsAsync(CancellationToken cancellationToken)
        {
            // TODO - Verify column names
            using DbConnection connection = GetTDMConnection();
            return await connection.QueryAsync<MaterialData>(new CommandDefinition("SELECT A.MATERIALID AS Id, a.NAME AS Name, (SELECT TOP 1 b.NAME FROM TDM_MATERIALGROUPS WHERE b.ID = a.MATERIALGROUPID) AS Group FROM TDM_MATERIAL AS a", commandType: CommandType.Text, cancellationToken: cancellationToken));
        }

        public static async Task<IEnumerable<MachineData>> GetMachinesAsync(CancellationToken cancellationToken)
        {
            using DbConnection connection = GetTDMConnection();
            return await connection.QueryAsync<MachineData>(new CommandDefinition("SELECT MACHINEID AS Id, NAME AS Name, MACHINEGROUPID AS Group FROM TDM_MATERIAL", commandType: CommandType.Text, cancellationToken: cancellationToken));
        }

        public static async Task<string> GetNextListIdAsync()
        {
            using DbConnection connection = GetTDMConnection();
            string currentMaxId = await connection.ExecuteScalarAsync<string>("SELECT MAX(LISTID) FROM TDM_LIST", commandType: CommandType.Text);
            if (int.TryParse(currentMaxId, out int idValue))
            {
                return CreateListIdFromInt(idValue, currentMaxId.Length);
            }
            return CreateListIdFromString(currentMaxId);
        }

        public static string CreateListIdFromString(string currentMaxId)
        {
            (int? numericSuffix, int suffixLenght) = GetListIdNumericSuffix(currentMaxId);
            if (numericSuffix == null)
            {
                return currentMaxId + "1";
            }
            return numericSuffix == null ? currentMaxId + "1" : currentMaxId[..^suffixLenght] + (numericSuffix + 1).ToString();
        }

        private static (int?, int) GetListIdNumericSuffix(string currentMaxId)
        {
            for (int i = 0; i < currentMaxId.Length; i++)
            {
                if (int.TryParse(currentMaxId[i..], out int suffix))
                {
                    return (suffix, currentMaxId.Length - i);
                }
            }
            return (null, 0);
        }

        private static string CreateListIdFromInt(int idValue, int length)
        {
            string output = idValue.ToString();
            for (int i = output.Length; i < length; i++)
            {
                output = "0" + output;
            }
            return output;
        }

        public async static Task<(List<ToolData> invalidTools, List<ToolData> validTools)> ValidateTools(List<ToolData>? tools)
        {
            List<ToolData> invalidTools = new();
            List<ToolData> validTools = new();
            if (tools == null)
            {
                return (invalidTools, validTools);
            }
            using DbConnection connection = GetTDMConnection();
            foreach (ToolData tool in tools)
	        {
                (invalidTools, validTools) = await ValidateTool(invalidTools, validTools, tool, connection);
	        }
            return (invalidTools, validTools);
        }

        private async static Task<(List<ToolData> invalidTools, List<ToolData> validTools)> ValidateTool(List<ToolData> invalidTools, List<ToolData> validTools, ToolData tool, DbConnection connection)
        {
            return tool.ToolType switch
            {
                ToolType.Item => await VerifyToolItem(invalidTools, validTools, tool, connection),
                ToolType.Assembly => await VerifyToolAssembly(invalidTools, validTools, tool, connection),
                _ => throw new ArgumentException("Invalid tool type", nameof(tool)),
            };
        }

        private async static Task<(List<ToolData> invalidTools, List<ToolData> validTools)> VerifyToolAssembly(List<ToolData> invalidTools, List<ToolData> validTools, ToolData tool, DbConnection connection)
        {
            if (await connection.ExecuteScalarAsync<int>(new CommandDefinition($"SELECT COUNT(TOOLID) FROM TDM_TOOL WHERE TOOLID = '{tool.Id}'", commandType: CommandType.Text)) > 0)
            {
                validTools.Add(tool);
                return (invalidTools, validTools);
            }
            invalidTools.Add(tool);
            return (validTools, invalidTools);
        }

        private async static Task<(List<ToolData> invalidTools, List<ToolData> validTools)> VerifyToolItem(List<ToolData> invalidTools, List<ToolData> validTools, ToolData tool, DbConnection connection)
        {
            tool.ItemDescription = CsvOperations.GetDictonaryDescriptionValue(tool.ItemDescription);
            if (await connection.ExecuteScalarAsync<int>(new CommandDefinition($"SELECT COUNT(COMPID) FROM TDM_COMP WHERE NAME2 = '{tool.ItemDescription}'", commandType: CommandType.Text)) == 0)
            {
                invalidTools.Add(tool);
                return (validTools, invalidTools);
            }
            tool.Id = await connection.ExecuteScalarAsync<string>(new CommandDefinition($"SELECT COMPID FROM TDM_COMP WHERE NAME2 = '{tool.ItemDescription}'", commandType: CommandType.Text));
            validTools.Add(tool);
            return (invalidTools, validTools);
        }

        public static async Task<string> ValidateListId(string id)
        {
            using DbConnection connection = GetTDMConnection();
            return await connection.ExecuteScalarAsync<int>(new CommandDefinition($"SELECT COUNT(LISTID) FROM TDM_LIST WHERE LISTID = '{id}'", commandType: CommandType.Text)) == 0 ? id : string.Empty;
        }
    }
}
