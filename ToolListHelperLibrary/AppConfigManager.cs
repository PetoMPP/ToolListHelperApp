using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperLibrary
{
    public class AppConfigManager
    {
        internal static string GetConnectionString(int timeout)
        {
            DatabaseMode databaseMode = GetDatabaseMode();
            string connectionString = GetDatabaseStringByMode(databaseMode);
            return timeout switch
            {
                15 => connectionString,
                _ => connectionString + (connectionString.EndsWith(";") ? $"Connection Timeout={timeout}" : $";Connection Timeout={timeout}")
            };
        }

        public static string GetSettingsPassPhrase()
        {
            return ConfigurationManager.AppSettings["SettingsPassPhrase"] ?? string.Empty;
        }

        public static string GetDatabaseStringByMode(DatabaseMode databaseMode)
        {
            return databaseMode switch
            {
                DatabaseMode.Test => ConfigurationManager.ConnectionStrings["TDM TEST"].ConnectionString,
                DatabaseMode.Prod => ConfigurationManager.ConnectionStrings["TDM PROD"].ConnectionString,
                _ => throw new InvalidOperationException(),
            };
        }

        public static DatabaseMode GetDatabaseMode()
        {
            string? databaseModeString = ConfigurationManager.AppSettings["DatabaseMode"];
            DatabaseMode databaseMode = Enum.Parse<DatabaseMode>(databaseModeString ?? "Test");
            return databaseMode;
        }

        internal static string? GetDescriptionsFilePath()
        {
            DictonaryMode dictonaryMode = GetDictonaryMode();
            return GetDictonaryPathByMode(dictonaryMode);
        }

        public static string? GetDictonaryPathByMode(DictonaryMode dictonaryMode)
        {
            return dictonaryMode switch
            {
                DictonaryMode.Global => ConfigurationManager.AppSettings["GlobalDictonaryRelativePath"],
                DictonaryMode.Local => ConfigurationManager.AppSettings["LocalDictonaryAbsolutePath"],
                _ => throw new InvalidOperationException(),
            };
        }

        public static void SetDatabaseMode(DatabaseMode databaseMode)
        {
            ConfigurationManager.AppSettings["DatabaseMode"] = databaseMode.ToString();
        }

        public static void SetDictonaryMode(DictonaryMode dictonaryMode)
        {
            ConfigurationManager.AppSettings["DictonaryMode"] = dictonaryMode.ToString();
        }

        public static void SetTestDatabaseConnectionString(string connectionString)
        {
            ConfigurationManager.ConnectionStrings["TDM TEST"].ConnectionString = connectionString;
        }

        public static void SetProdDatabaseConnectionString(string connectionString)
        {
            ConfigurationManager.ConnectionStrings["TDM PROD"].ConnectionString = connectionString;
        }

        public static DictonaryMode GetDictonaryMode()
        {
            string? dictonaryModeString = ConfigurationManager.AppSettings["DictonaryMode"];
            DictonaryMode dictonaryMode = Enum.Parse<DictonaryMode>(dictonaryModeString ?? "Global");
            return dictonaryMode;
        }

        public static void SetSettingsPassPhrase(string passPhrase)
        {
            ConfigurationManager.AppSettings["SettingsPassPhrase"] = passPhrase;
        }

        public static void SetGlobalDictonaryPath(string path)
        {
            ConfigurationManager.AppSettings["GlobalDictonaryRelativePath"] = path;
        }

        public static void SetLocalDictonaryPath(string path)
        {
            ConfigurationManager.AppSettings["LocalDictonaryAbsolutePath"] = path;
        }
    }
}
