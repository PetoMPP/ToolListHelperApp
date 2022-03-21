using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolListHelperLibrary.Models;

namespace ToolListHelperLibrary
{
    public class CsvOperations
    {
        public static Dictionary<string, string> LoadDescriptionsDictonary()
        {
            string? path = AppConfigManager.GetDescriptionsFilePath();
            if (path == null)
            {
                return new Dictionary<string, string>();
            }
            using StreamReader streamReader = new(path);
            CsvConfiguration csvConfiguration = new(CultureInfo.InvariantCulture);
            csvConfiguration.HasHeaderRecord = false;
            using CsvReader csvReader = new(streamReader, csvConfiguration);
            IEnumerable<FusionDataRecord> data = csvReader.GetRecords<FusionDataRecord>();
            Dictionary<string, string> itemDescriptions = new();
            foreach (FusionDataRecord fusionDataRecord in data)
            {
                itemDescriptions.Add(fusionDataRecord.Key, fusionDataRecord.Value);
            }
            return itemDescriptions;
        }

        internal static string GetDictonaryDescriptionValue(string itemDescription)
        {
            Dictionary<string, string> keyValuePairs = LoadDescriptionsDictonary();
            return keyValuePairs.TryGetValue(itemDescription, out string? description) ? description : itemDescription;
        }

        public static void OverwriteDictonary(Dictionary<string, string> updatedDictonary)
        {
            string path = AppConfigManager.GetDescriptionsFilePath() ?? throw new Exception("No path configured!");
            using StreamWriter streamWriter = new(path, false);
            using CsvWriter csvWriter = new(streamWriter, CultureInfo.InvariantCulture);
            foreach (KeyValuePair<string, string> keyValuePair in updatedDictonary)
            {
                csvWriter.WriteRecord(new FusionDataRecord() { Key = keyValuePair.Key, Value = keyValuePair.Value });
                csvWriter.NextRecord();
            }
        }

        public static Dictionary<string, string> GetDictonaryFromTextFile(string fileName)
        {
            Dictionary<string, string> output = new();
            foreach (string line in File.ReadAllLines(fileName))
            {
                string[] values = line.Split(": ");
                output[values[0]] = values[1];
            }
            return output;
        }
    }
}
