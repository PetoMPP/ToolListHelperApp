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
        internal static DbConnection GetTDMConnection(int timeout = 15)
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
                if (!model.SkipNcFile)
                {
                    await ExecuteFileTransfer(model, connection);
                    // TODO - Check if tdm logs file transfers
                    // await InsertLog(model, connection, logMessage);
                }
            }
            catch (Exception error)
            {
                return (model.Id, error.Message);
            }
            return (model.Id, string.Empty);
        }

        private async static Task ExecuteFileTransfer(ListModel model, DbConnection connection)
        {
            // Get machine paths
            Dictionary<NcFileMode, string>? machinePaths = await GetMachinePathsDictonary(model.Machine ?? string.Empty, connection);
            NcFileMode ncFileMode = model.NcFile.NcFileMode;
            string filePath = model.NcFile.FilePath ?? string.Empty;
            string targetPath;
            if (model.CreatingMode == CreatingMode.New)
            {
                targetPath = Path.Combine(machinePaths[NcFileMode.Archive], model.Name?.ToUpper() ?? string.Empty) + '.' + CreateVersionString(1) + '.' + Path.GetExtension(filePath);
                await SendNewFile(model, connection, GetStateNameFromNcFileMode(ncFileMode), filePath, 1, targetPath);
                return;
            }
            // Get next Version num
            int nextVersion = await GetNcFileMaxVersion(model.Id, connection) + 1;
            // If creating as released for prod and there is already released move it back to archive
            if (ncFileMode == NcFileMode.Release && await CheckIfAnyNcFileIsReleased(model.Id, connection))
            {
                await MoveReleasedFileToArchive(model, machinePaths, connection);
            }
            targetPath = Path.Combine(machinePaths[NcFileMode.Archive], model.Name?.ToUpper() ?? string.Empty) + '.' + CreateVersionString(nextVersion) + '.' + Path.GetExtension(filePath);
            // Copy source file to machine path
            // Update file state
            await SendNewFile(model, connection, GetStateNameFromNcFileMode(ncFileMode), filePath, nextVersion, targetPath);
        }

        private async static Task SendNewFile(ListModel model, DbConnection connection, string targetState, string filePath, int version, string targetPath)
        {
            File.Copy(filePath, targetPath);
            await InsertFileState(model, version, targetState, Path.GetExtension(filePath).ToUpper(), connection);
        }

        private async static Task InsertFileState(ListModel model, int version, string targetState, string extension, DbConnection connection)
        {
            // TODO - Fix column names
            await connection.ExecuteAsync(new CommandDefinition(@$"
INSERT INTO NCM_PRODDOCB (FILEID, LISTID, EXTENSION, STATEID, VERSION) 
VALUES '{model.Name?.ToUpper()}', '{model.Id}', '{extension}', '{targetState}', {version}", commandType: CommandType.Text));
        }

        private static async Task SendUpdateFile(string id, DbConnection connection, string targetState, string filePath, int version, string targetPath)
        {
            File.Move(filePath, targetPath);
            await SetFileState(id, version, targetState, connection);
        }

        private async static Task MoveReleasedFileToArchive(ListModel model, Dictionary<NcFileMode, string> machinePaths, DbConnection connection)
        {
            // Get path of file
            int version = await GetNcFileMaxVersion(model.Id, connection, NcFileMode.Release);
            string versionString = CreateVersionString(version);
            string extension = await GetNcFileExtension(model.Id, version, connection);
            string filePath = Path.Combine(machinePaths[NcFileMode.Release], model.Name ?? string.Empty) + '.' + versionString + '.' + extension;
            // Get target path
            string targetPath = Path.Combine(machinePaths[NcFileMode.Archive], model.Name ?? string.Empty) + '.' + versionString + '.' + extension;
            try
            {
                await SendUpdateFile(model.Id, connection, GetStateNameFromNcFileMode(NcFileMode.Archive), filePath, version, targetPath);
            }
            catch (FileNotFoundException)
            {
                await DeleteFileEntry(model.Id, version, connection);
            }
        }


        private static async Task DeleteFileEntry(string id, int version, DbConnection connection)
        {
            await connection.ExecuteAsync(new CommandDefinition($"DELETE FROM NCM_PRODDOCB WHERE LISTID = '{id}' AND VERSION = {version}", commandType: CommandType.Text));
        }

        private static async Task SetFileState(string id, int version, string state, DbConnection connection)
        {
            await connection.ExecuteAsync(new CommandDefinition($"UPDATE NCM_PRODDOCB SET STATEID = '{state}' WHERE LISTID = '{id}' AND VERSION = {version}", commandType: CommandType.Text));
        }

        private static async Task<string> GetNcFileExtension(string id, int version, DbConnection connection)
        {
            return await connection.ExecuteScalarAsync<string>(new CommandDefinition($"SELECT EXTENSION FROM NCM_PRODDOCB WHERE VERSION = {version} AND LISTID = '{id}'", commandType: CommandType.Text));
        }

        private static string CreateVersionString(int version)
        {
            string versionString = version.ToString();
            for (int i = versionString.Length; i < 5; i++)
            {
                versionString = "0" + versionString;
            }
            return versionString;
        }

        private static async Task<bool> CheckIfAnyNcFileIsReleased(string id, DbConnection connection)
        {
            return await connection.ExecuteScalarAsync<bool>(new CommandDefinition($"SELECT COUNT(STATEID) FROM NCM_PRODDOCB WHERE STATEID = 'RELEASE FOR PRODUCTION' AND LISTID = '{id}'", commandType: CommandType.Text));
        }

        private async static Task<int> GetNcFileMaxVersion(string id, DbConnection connection)
        {
            return await connection.ExecuteScalarAsync<int>(new CommandDefinition($"SELECT MAX(VERSION) FROM NCM_PRODDOCB WHERE LISTID = '{id}'", commandType: CommandType.Text));
        }
        private async static Task<int> GetNcFileMaxVersion(string id, DbConnection connection, NcFileMode ncFileMode)
        {
            return await connection.ExecuteScalarAsync<int>(new CommandDefinition($"SELECT MAX(VERSION) FROM NCM_PRODDOCB WHERE LISTID = '{id}' AND STATEID = '{GetStateNameFromNcFileMode(ncFileMode)}'", commandType: CommandType.Text));
        }

        private static async Task<Dictionary<NcFileMode, string>> GetMachinePathsDictonary(string machine, DbConnection connection)
        {
            Dictionary<NcFileMode, string> fileModesPathes = new();
            List<(string state, string path)> pathsForMachine = (await connection.QueryAsync<(string state, string path)>(new CommandDefinition($@"
SELECT PATH AS path, STATEID AS state
FROM TDM_MACHINESTATEPATH
WHERE MACHINEID = '{machine}'"))).ToList();
            foreach (NcFileMode fileMode in Enum.GetValues<NcFileMode>())
            {
                fileModesPathes.Add(fileMode, pathsForMachine.Where(p => p.state == GetStateNameFromNcFileMode(fileMode)).First().path);
            }
            return fileModesPathes;
        }

        private static string GetStateNameFromNcFileMode(NcFileMode fileMode)
        {
            return fileMode switch
            {
                NcFileMode.Archive => "ARCHIVE",
                NcFileMode.Developing => "NC DEVELOPING",
                NcFileMode.Release => "RELEASE FOR PRODUCTION",
                _ => throw new InvalidOperationException()
            };
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
            int timeDifference = TimeZoneInfo.Local.BaseUtcOffset.Hours * 3600;
            int changeDate = epochDictonary[timestamp - changeTime - timeDifference];
            return (changeDate, changeTime + timeDifference);
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
            int timestamp = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
            string header;
            if (model.Tools == null || model.Tools.Count == 0)
            {
                throw new ArgumentException("Tools list cannot be null or empty!", nameof(model));
            }
            if (model.Tools.Any(t => t.ToolType == ToolType.Assembly) && model.Tools.Any(t => t.ToolType == ToolType.Item))
            {
                throw new NotSupportedException("List of Tools with diffirent tool types are not supported!");
            }
            if (model.Tools.Any(t => t.ToolType == ToolType.Assembly))
            {
                header = "INSERT INTO TDM_LISTLISTB (LISTID, LISTLISTPOS, TOOLID, TIMESTAMP) VALUES ";
            }
            else
            {
                header = "INSERT INTO TDM_LISTLISTB (LISTID, LISTLISTPOS, COMPID, TIMESTAMP) VALUES ";
            }
            StringBuilder stringBuilder = new(header);
            for (int i = 0; i < model.Tools.Count; i++)
            {
                stringBuilder.Append($"('{model.Id}', {i + 1}, '{model.Tools[i].Id}', {timestamp}),");
            }
            stringBuilder.Length--;
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
            stringBuilder.Append($"WHERE LISTID = '{model.Id}'");
            return stringBuilder.ToString();
        }

        private async static Task<string> GetUserNameFromUserId(string creatorId, DbConnection connection)
        {
            return await connection.ExecuteScalarAsync<string>($"SELECT CONCAT(FIRSTNAME, ' ', NAME) FROM TMS_USER WHERE USERNAME = '{creatorId}'");
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
            stringBuilder.Append(model.ListStatus == ListStatus.Preparing ? "'TOOL LIST IS PREPARING'," : "'TOOL LIST IS DONE',");
            stringBuilder.Append($"{(model.ListType == null ? (int)ListType.Primary : (int)model.ListType)},");
            stringBuilder.Append($"'{await GetUserNameFromUserId(model.CreatorId, connection)}')");
            return stringBuilder.ToString();
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
            using DbConnection connection = GetTDMConnection();
            return await connection.QueryAsync<MaterialData>(new CommandDefinition("SELECT A.MATERIALID AS Id, a.NAME AS Name, (SELECT TOP 1 b.NAME01 FROM TDM_MATERIALGROUP AS b WHERE b.MATERIALGROUPID = a.MATERIALGROUPID) AS ParentGroup FROM TDM_MATERIAL AS a", commandType: CommandType.Text, cancellationToken: cancellationToken));
        }

        public static async Task<IEnumerable<MachineData>> GetMachinesAsync(CancellationToken cancellationToken)
        {
            using DbConnection connection = GetTDMConnection();
            return await connection.QueryAsync<MachineData>(new CommandDefinition("SELECT MACHINEID AS Id, NAME AS Name, MACHINEGROUPID AS ParentGroup FROM TDM_MACHINE", commandType: CommandType.Text, cancellationToken: cancellationToken));
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
            string output = (idValue + 1).ToString();
            for (int i = output.Length; i < length; i++)
            {
                output = "0" + output;
            }
            return output;
        }

        public async static Task<(List<ToolData> invalidTools, List<ToolData> validTools)> ValidateToolsAsync(List<ToolData>? tools)
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
                (invalidTools, validTools) = await ValidateToolAsync(invalidTools, validTools, tool, connection);
            }
            return (invalidTools, validTools);
        }

        private async static Task<(List<ToolData> invalidTools, List<ToolData> validTools)> ValidateToolAsync(List<ToolData> invalidTools, List<ToolData> validTools, ToolData tool, DbConnection connection)
        {
            return tool.ToolType switch
            {
                ToolType.Item => await VerifyToolItemAsync(invalidTools, validTools, tool, connection),
                ToolType.Assembly => await VerifyToolAssemblyAsync(invalidTools, validTools, tool, connection),
                _ => throw new ArgumentException("Invalid tool type", nameof(tool)),
            };
        }

        private async static Task<(List<ToolData> invalidTools, List<ToolData> validTools)> VerifyToolAssemblyAsync(List<ToolData> invalidTools, List<ToolData> validTools, ToolData tool, DbConnection connection)
        {
            if (await connection.ExecuteScalarAsync<int>(new CommandDefinition($"SELECT COUNT(TOOLID) FROM TDM_TOOL WHERE TOOLID = '{tool.Id}'", commandType: CommandType.Text)) > 0)
            {
                validTools.Add(tool);
                return (invalidTools, validTools);
            }
            invalidTools.Add(tool);
            return (invalidTools, validTools);
        }

        private async static Task<(List<ToolData> invalidTools, List<ToolData> validTools)> VerifyToolItemAsync(List<ToolData> invalidTools, List<ToolData> validTools, ToolData tool, DbConnection connection)
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

        public async static Task<bool> ValidateUserAsync(string creator)
        {
            using DbConnection connection = GetTDMConnection();
            return await connection.ExecuteScalarAsync<bool>(new CommandDefinition($"SELECT COUNT(USERID) FROM TMS_USER WHERE USERNAME = '{creator}'"));
        }

        public static async Task<bool> ValidateListIdAsync(string id)
        {
            using DbConnection connection = GetTDMConnection();
            return await connection.ExecuteScalarAsync<bool>(new CommandDefinition($"SELECT COUNT(LISTID) FROM TDM_LIST WHERE LISTID = '{id}'", commandType: CommandType.Text));
        }
		
		public async static Task DeleteNcProgramsAsync(List<string> listsIds)
        {
            foreach (string listId in listsIds)
            {
                // Get List of NC programs with file locations
                List<string> filePaths = await GetNcFilesPathsAsync(listId) ?? new();
                // Delete files ignoring exception if file is not found
                if (filePaths != null)
                {
                    foreach (string filePath in filePaths)
                    {
                        try
                        {
                            File.Delete(filePath);
                        }
                        catch (FileNotFoundException)
                        {
                            ;
                        }
                    } 
                }
                // Delete db entries
                await DeleteNcProgramsDbDataAsync(listId);
            }
        }

		public async static Task<List<string>> VerifyListsIdsAsync(List<string> listsIds)
        {
            List<string> verifiedListsIds = new();
            using DbConnection cnxn = GetTDMConnection();
            foreach (string listId in listsIds)
            {
                string id = await cnxn.ExecuteScalarAsync<string>($"SELECT LISTID FROM TDM_LIST WHERE LISTID = '{listId}'", commandType: CommandType.Text);
                if (id != null)
                {
                    verifiedListsIds.Add(id);
                }
            }
            return verifiedListsIds;
        }

        private async static Task DeleteNcProgramsDbDataAsync(string listId)
        {
            using DbConnection cnxn = GetTDMConnection();
            await cnxn.ExecuteAsync($"DELETE FROM NCM_PRODDOCB WHERE LISTID = '{listId}'", commandType: CommandType.Text);
        }

        private async static Task<List<string>?> GetNcFilesPathsAsync(string listId)
        {
            List<string> filePaths = new();
            using DbConnection cnxn = GetTDMConnection();
            // Get Machine
            string machineId = await GetMachineIDAsync(cnxn, listId);
            // Skip looking for files if machine is not specified
            if (machineId == null)
            {
                return null;
            }
            // Get file data
            List<NcProgramFileModel> ncPrograms = await GetNcProgramsDataAsync(cnxn, listId);
            foreach (NcProgramFileModel ncProgram in ncPrograms)
            {
                // Set Machine for nc programs
                ncProgram.MachineId = machineId;
                // Get path for machine and status
                ncProgram.Path = await GetNcProgramPathAsync(cnxn, ncProgram.MachineId, ncProgram.StateId ?? string.Empty);
                // Create path for file
                filePaths.Add(CreateFilePath(ncProgram));
            }
            return filePaths;
        }

        private static string CreateFilePath(NcProgramFileModel ncProgram) =>
            ncProgram.Path + "\\" + ncProgram.FileId + "." + CreateFileVersionIndex(ncProgram.Version) + "." + ncProgram.Extension;

        private static string CreateFileVersionIndex(int version)
        {
            string index = version.ToString();
            while (index.Length < 4)
            {
                index = "0" + index;
            }
            return index;
        }

        private async static Task<string> GetNcProgramPathAsync(IDbConnection cnxn, string machineId, string stateId) =>
            (await cnxn.QueryAsync<string>($@"
SELECT PATH AS Path
FROM TDM_MACHINESTATEPATH
WHERE MACHINEID = '{machineId}' AND STATEID = '{stateId}'")).First();

        private async static Task<List<NcProgramFileModel>> GetNcProgramsDataAsync(IDbConnection cnxn, string listId) =>
            (await cnxn.QueryAsync<NcProgramFileModel>(@$"
SELECT FILEID AS FileId, EXTENSION AS Extension, STATEID AS StateId, VERSION AS Version
FROM NCM_PRODDOCB
WHERE LISTID = '{listId}'")).ToList();

        private async static Task<string> GetMachineIDAsync(IDbConnection cnxn, string listId) =>
            (await cnxn.QueryAsync<string>($"SELECT MACHINEID FROM TDM_LIST WHERE LISTID = '{listId}'", commandType: CommandType.Text)).First();

        public async static Task DeleteToolListsAsync(List<string> listsIds)
        {
            foreach (string listId in listsIds)
            {
                using IDbConnection cnxn = GetTDMConnection();
                // Delete positions
                await cnxn.ExecuteAsync($"DELETE FROM TDM_LISTLISTB WHERE LISTID = '{listId}'", commandType: CommandType.Text);
                // Delete Master Data
                await cnxn.ExecuteAsync($"DELETE FROM TDM_LIST WHERE LISTID = '{listId}'", commandType: CommandType.Text);
            }
        }
    }
}
