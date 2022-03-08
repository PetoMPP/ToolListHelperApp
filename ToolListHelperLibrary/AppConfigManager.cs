using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperLibrary
{
    internal class AppConfigManager
    {
        internal static string GetConnectionString(int timeout)
        {
            string? databaseModeString = ConfigurationManager.AppSettings["DatabaseMode"];
            DatabaseMode databaseMode = Enum.Parse<DatabaseMode>(databaseModeString ?? "Test");
            string connectionString = databaseMode switch
            {
                DatabaseMode.Test => ConfigurationManager.ConnectionStrings["TDM TEST"].ConnectionString,
                DatabaseMode.Prod => ConfigurationManager.ConnectionStrings["TDM PROD"].ConnectionString,
                _ => throw new InvalidOperationException(),
            };
            return timeout switch
            {
                15 => connectionString,
                _ => connectionString + (connectionString.EndsWith(";") ? $"Connection Timeout={timeout}" : $";Connection Timeout={timeout}")
            };
        }

        internal static string? GetDescriptionsFilePath()
        {
            string? dictonaryModeString = ConfigurationManager.AppSettings["DictonaryMode"];
            DictonaryMode dictonaryMode = Enum.Parse<DictonaryMode>(dictonaryModeString ?? "Global");
            return dictonaryMode switch
            {
                DictonaryMode.Global => ConfigurationManager.AppSettings["GlobalDictonaryRelativePath"],
                DictonaryMode.Local => ConfigurationManager.AppSettings["LocalDictonaryAbsolutePath"],
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
