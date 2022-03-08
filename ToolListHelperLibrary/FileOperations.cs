using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToolListHelperLibrary.Models;

namespace ToolListHelperLibrary
{
    public class FileOperations
    {
        public static NcFileType GetFileTypeFromFile()
        {
            throw new NotImplementedException();
        }

        public async static Task<List<ToolData>> GetToolsFromFilesAsync(string[] filePaths, NcFileType ncFileType)
        {
            string data = string.Empty;
            foreach (string filePath in filePaths)
            {
                data += await File.ReadAllTextAsync(filePath);
            }
            return ncFileType switch
            {
                NcFileType.Sinumeric => GetToolDataSinumeric(data),
                NcFileType.Fusion => GetToolDataFusion(data),
                NcFileType.ShopTurn => GetToolDataShopTurn(data),
                NcFileType.Auto => GetToolDataAuto(data),
                _ => throw new InvalidDataException()
            };
        }

        private static List<ToolData> GetToolDataAuto(string data)
        {
            List<ToolData> sinuData = GetToolDataSinumeric(data);
            List<ToolData> fusionData = GetToolDataFusion(data);
            List<ToolData> shopTurnData = GetToolDataShopTurn(data);
            if (sinuData.Count > fusionData.Count && sinuData.Count > shopTurnData.Count)
            {
                return sinuData;
            }
            if (fusionData.Count > shopTurnData.Count)
            {
                return fusionData;
            }
            return shopTurnData;
        }

        public static List<ToolData> GetToolDataShopTurn(string data)
        {
            List<ToolData> output = new();
            MatchCollection? toolNames = Regex.Matches(data, @"""(?'Id'[a-zA-Z]{1}[a-zA-Z0-9]{1,31})""");
            foreach (Match match in toolNames)
            {
                output.Add(new ToolData() { Id = match.Groups["Id"].Value, ToolType = ToolType.Assembly });
            }
            output = output.Distinct().ToList();
            return output;
        }

        public static List<ToolData> GetToolDataFusion(string data)
        {
            List<ToolData> output = new();
            MatchCollection? toolNames = Regex.Matches(data, @"""ArticleNr"":""(?'Id'[\w_\- .,/°*]+)""");
            foreach (Match match in toolNames)
            {
                output.Add(new ToolData() { ItemDescription = match.Groups["Id"].Value, ToolType = ToolType.Item });
            }
            output = output.Distinct().ToList();
            return output;
        }

        public static List<ToolData> GetToolDataSinumeric(string data)
        {
            List<ToolData> output = new();
            MatchCollection? toolNames = Regex.Matches(data, "T=\"(?'Id'.+)\"");
            foreach (Match match in toolNames)
            {
                if (match.Groups["Id"].Value == "SONDA")
                {
                    continue;
                }
                output.Add(new ToolData() { Id = match.Groups["Id"].Value, ToolType = ToolType.Assembly });
            }
            output = output.Distinct().ToList();
            return output;
        }

        public static string GetProgramNameFromFile(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        public static (string, int) ValidateProgramPaths(string[] filePaths, int errorCounter)
        {
            string errorMessage = string.Empty;
            foreach (string? path in filePaths)
            {
                FileInfo fileInfo = new(path);
                if (!fileInfo.Exists)
                {
                    errorMessage += $"{errorCounter}. Plik {fileInfo.Name} does not exist.";
                    errorCounter++;
                }
            }
            return(errorMessage, errorCounter);
        }
    }
}
