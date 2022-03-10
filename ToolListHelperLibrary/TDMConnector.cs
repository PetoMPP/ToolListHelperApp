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
                CreatingMode.New => await CreateListAsync(model, connection, "Lista stworzona za pomocą programu Tool List Maker"),
                CreatingMode.Update => await UpdateListAsync(model, connection, "Lista zaktualizowana za pomocą programu Tool List Maker"),
                _ => throw new ArgumentException("Invalid Creating Mode", nameof(model)),
            };
        }

        private async static Task<(string listId, string errorMessage)> UpdateListAsync(ListModel model, DbConnection connection, string logMessage)
        {
            try
            {
                // Change List Data
                await connection.ExecuteAsync(new CommandDefinition(await GenerateUpdateStringFromModelAsync(model, connection), commandType: CommandType.Text));
                // Overwrite Tool List
                await OverwriteTools(model, connection);
                // Insert Logfile
                await InsertLog(model, connection, logMessage);
            }
            catch (Exception error)
            {
                return (model.Id, error.Message);
            }
            return (model.Id, string.Empty);
        }

        private static async Task InsertLog(ListModel model, DbConnection connection, string logMessage)
        {
            await connection.ExecuteAsync(new CommandDefinition(await GenerateLogInsertString(model, connection, logMessage)));
        }

        private static async Task OverwriteTools(ListModel model, DbConnection connection)
        {
            await connection.ExecuteAsync(new CommandDefinition($"DELETE FROM TDM_LISTLISTB WHERE LISTID = '{model.Id}'"));
            if (model.Tools?.Count > 0)
            {
                await connection.ExecuteAsync(new CommandDefinition(GenerateInsertToolsStringFromModel(model), commandType: CommandType.Text));
            }
        }

        private async static Task<string> GenerateLogInsertString(ListModel model, DbConnection connection, string logMessage)
        {
            int timestamp = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
            (int changeDate, int changeTime) = GetChangeDate(timestamp);
            return @$"
INSERT INTO TMS_CHANGEINFO (TIMESTAMP, TNAME, ID, POS, USERID, NOTE, CHANGEDATE, CHANGETIME, CREATIONTIMESTAMP) 
VALUES ({timestamp} , 'TDM_LIST', '{model.Id}', '{await GetNextLogfilePosition(model.Id, connection)}', '{model.CreatorId}','{logMessage}' ,{changeDate}, {changeTime}, {timestamp})";
        }

        public static (int changeDate, int changeTime) GetChangeDate(int timestamp)
        {
            Dictionary<int, int> epochDictonary = CreateEpochDixtonary();
            int changeTime = timestamp % 86400;
            if (epochDictonary.TryGetValue(timestamp - changeTime - 7200, out int changeDate))
            {
                return (changeDate, changeTime);
            }
            changeDate = epochDictonary[timestamp - changeTime - 3600];
            return (changeDate, changeTime);
        }

        private static Dictionary<int, int> CreateEpochDixtonary()
        {
            Dictionary<int, int> epochDictonary = new();
            List<int> epochKeys = CreateRange(1543100400, 1975096800, 86400).ToList();
            List<int> tdmValues = Enumerable.Range(153000, 158000).ToList();
            for (int i = 0; i < epochKeys.Count; i++)
            {
                epochDictonary.Add(epochKeys[i], tdmValues[i]);
            }
            return epochDictonary;
        }

        private static IEnumerable<int> CreateRange(int startValue, int endVal, int step)
        {
            for (int i = startValue; i < endVal; i += step)
            {
                yield return i;
            }
        }

        private static async Task<int> GetNextLogfilePosition(string id, DbConnection connection)
        {
            return (await connection.ExecuteScalarAsync<int>(new CommandDefinition($"SELECT MAX(POS) FROM TMS_CHANGEINFO WHERE ID = '{id}' AND TNAME = 'TDM_LIST'", commandType: CommandType.Text))) + 1;
        }

        private static string GenerateInsertToolsStringFromModel(ListModel model)
        {
            // TODO - Fix Column names
            int timestamp = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
            string header;
            if (model.Tools == null || model.Tools.Count == 0)
            {
                throw new ArgumentException("Tools list cannot be null or empty!", nameof(model));
            }
            if (model.Tools.Select(t => t.ToolType == ToolType.Assembly).Any() && model.Tools.Select(t => t.ToolType == ToolType.Item).Any())
            {
                throw new NotSupportedException("List of Tools with diffirent tool types are not supported!");
            }
            if (model.Tools.Select(t => t.ToolType == ToolType.Assembly).Any())
            {
                header = "INSERT INTO TDM_LISTLISTB (LISTID, POS, TOOLID, TIMESTAMP) VALUES (";
            }
            else
            {
                header = "INSERT INTO TDM_LISTLISTB (LISTID, POS, COMPID, TIMESTAMP) VALUES (";
            }
            StringBuilder stringBuilder = new(header);
            for (int i = 0; i < model.Tools.Count; i++)
            {
                stringBuilder.Append($"('{model.Id}', {i}, '{model.Tools[i].Id}', {timestamp}),");
            }
            stringBuilder.Length--;
            stringBuilder.Append(')');
            return stringBuilder.ToString();
        }

        private async static Task<string> GenerateUpdateStringFromModelAsync(ListModel model, DbConnection connection)
        {
            string startString = "UPDATE TDM_LIST SET ";
            StringBuilder stringBuilder = new(startString);
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
                if (model.Material != null)
                {
                    stringBuilder.Append($"MATERIALID = '{model.Material}',");
                }
                else
                {
                    stringBuilder.Append("MATERIALID = NULL,");
                }
            }
            if (!model.SkipClamping)
            {
                if (model.Clamping != null)
                {
                    stringBuilder.Append($"FIXTURE = '{model.Clamping}',");
                }
                else
                {
                    stringBuilder.Append("FIXTURE = NULL,");
                }
            }
            if (!model.SkipListType)
            {
                stringBuilder.Append($"LISTTYPE = '{(int?)model.ListType}',");
            }
            stringBuilder.Append($"USERNAME = '{await GetUserNameFromUserId(model.CreatorId, connection)}'");
            stringBuilder.Append($"WHERE TOOLID = '{model.Id}'");
            return stringBuilder.ToString();
        }

        private async static Task<string> GetUserNameFromUserId(string creatorId, DbConnection connection)
        {
            return await connection.ExecuteScalarAsync<string>($"SELECT CONCAT(FIRSTNAME, '', NAME) FROM TMS_USER WHERE USERNAME = '{creatorId}'");
        }

        private async static Task<string> GetMachineGroupIdByMachineIdAsync(string machine, DbConnection connection)
        {
            return await connection.ExecuteScalarAsync<string>($"SELECT MACHINEGROUPID FROM TDM_MACHINE WHERE MACHINEID = '{machine}'");
        }

        private async static Task<(string listId, string errorMessage)> CreateListAsync(ListModel model, DbConnection connection, string logMessage)
        {
            try
            {
                // Change List Data
                await connection.ExecuteAsync(new CommandDefinition(await GenerateCreationStringFromModelAsync(model, connection), commandType: CommandType.Text));
                // Overwrite Tool List
                await OverwriteTools(model, connection);
                // Insert Logfile
                await InsertLog(model, connection, logMessage);
            }
            catch (Exception error)
            {
                return (model.Id, error.Message);
            }
            return (model.Id, string.Empty);
        }

        private static async Task<string> GenerateCreationStringFromModelAsync(ListModel model, DbConnection connection)
        {
            StringBuilder stringBuilder = new ("INSERT INTO TDM_LIST (TIMESTAMP, LISTID, NCPROGRAM, PARTNAME, WORKPIECEDRAWING, MATERIALID, MACHINEID, MACHINEGROUPID, FIXTURE, STATEID1, LISTTYPE, USERNAME) VALUES (");
            stringBuilder.Append($"{DateTimeOffset.Now.ToUnixTimeSeconds()},");
            stringBuilder.Append($"'{model.Id}',");
            stringBuilder.Append(model.Name == null ? "NULL," : $"'{model.Name}',");
            stringBuilder.Append(model.Description == null ? "NULL," : $"'{model.Description}',");
            stringBuilder.Append($"'{model.Id}',");
            stringBuilder.Append(model.Material == null ? "NULL," : $"'{model.Material}',");
            stringBuilder.Append(model.Machine == null ? "NULL,NULL," : $"'{model.Machine}','{await GetMachineGroupIdByMachineIdAsync(model.Machine, connection)}',");
            stringBuilder.Append(model.Clamping == null ? "NULL," : $"'{model.Clamping}',");
            // TODO - Fix status string
            stringBuilder.Append(model.ListStatus == ListStatus.Preparing ? "'TOOL LIST IS PREPARING'" : "'TOOL LIST READY'");
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

        public async static Task<bool> ValidateUser(string creator)
        {
            using DbConnection connection = GetTDMConnection();
            return await connection.ExecuteScalarAsync<bool>(new CommandDefinition($"SELECT COUNT(USERID) FROM TMS_USER WHERE USERNAME = '{creator}'"));
        }

        public static async Task<bool> ValidateListId(string id)
        {
            using DbConnection connection = GetTDMConnection();
            return await connection.ExecuteScalarAsync<bool>(new CommandDefinition($"SELECT COUNT(LISTID) FROM TDM_LIST WHERE LISTID = '{id}'", commandType: CommandType.Text));
        }
    }
}
