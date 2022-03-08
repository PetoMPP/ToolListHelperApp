using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperLibrary
{
    public class CsvOperations
    {
        private static readonly Dictionary<string, string> _itemDescriptions = LoadDescriptionsDictonary();

        private static Dictionary<string, string> LoadDescriptionsDictonary()
        {
            string? path = AppConfigManager.GetDescriptionsFilePath();
            if (path == null)
            {
                return new Dictionary<string, string>();
            }
            using StreamReader streamReader = new(path);
            using CsvReader csvReader = new(streamReader, CultureInfo.InvariantCulture);
            IEnumerable<KeyValuePair<string, string>>? data = csvReader.GetRecords<KeyValuePair<string, string>>();
            Dictionary<string, string> itemDescriptions = new();
            foreach (KeyValuePair<string, string> kvp in data)
            {
                itemDescriptions.Add(kvp.Key, kvp.Value);
            }
            return itemDescriptions;
        }

        internal static string GetDictonaryDescriptionValue(string itemDescription)
        {
            return _itemDescriptions.TryGetValue(itemDescription, out string? description) ? description : itemDescription;
        }
    }
}
