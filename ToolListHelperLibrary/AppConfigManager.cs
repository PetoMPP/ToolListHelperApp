using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ToolListHelperLibrary
{
    public class AppConfigManager
    {
        private const string ConfigPath = "config.xml";
        public static XmlDocument GetConfigAsXml()
        {
            XmlDocument xmlDocument = new();
            xmlDocument.Load(ConfigPath);
            return xmlDocument;
        }
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
            XmlDocument config = GetConfigAsXml();
            return config.SelectSingleNode("configuration/appSettings/SettingsPassPhrase")?.Attributes?["value"]?.Value ?? string.Empty;
        }

        public static string GetDatabaseStringByMode(DatabaseMode databaseMode)
        {
            XmlDocument config = GetConfigAsXml();
            return databaseMode switch
            {
                //DatabaseMode.Test => ConfigurationManager.ConnectionStrings["TDM TEST"].ConnectionString,
                DatabaseMode.Test => config.SelectSingleNode("configuration/connectionStrings/TDMTEST")?.Attributes?["connectionString"]?.Value ?? string.Empty,
                //DatabaseMode.Prod => ConfigurationManager.ConnectionStrings["TDM PROD"].ConnectionString,
                DatabaseMode.Prod => config.SelectSingleNode("configuration/connectionStrings/TDMPROD")?.Attributes?["connectionString"]?.Value ?? string.Empty,
                _ => throw new InvalidOperationException(),
            };
        }

        public static DatabaseMode GetDatabaseMode()
        {
            XmlDocument config = GetConfigAsXml();
            //string? databaseModeString = ConfigurationManager.AppSettings["DatabaseMode"];
            string? databaseModeString = config.SelectSingleNode("configuration/appSettings/DatabaseMode")?.Attributes?["value"]?.Value;
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
            XmlDocument config = GetConfigAsXml();
            return dictonaryMode switch
            {
                DictonaryMode.Global => config.SelectSingleNode("configuration/appSettings/GlobalDictonaryRelativePath")?.Attributes?["value"]?.Value,
                DictonaryMode.Local => config.SelectSingleNode("configuration/appSettings/LocalDictonaryAbsolutePath")?.Attributes?["value"]?.Value,
                _ => throw new InvalidOperationException(),
            };
        }

        public static void SetDatabaseMode(DatabaseMode databaseMode)
        {
            XmlDocument config = GetConfigAsXml();
            XmlAttribute? xmlAttribute = config.SelectSingleNode("configuration/appSettings/DatabaseMode")?.Attributes?["value"];
            if (xmlAttribute != null)
            {
                xmlAttribute.Value = databaseMode.ToString();
                config.Save(ConfigPath);
            }
        }

        public static void SetDictonaryMode(DictonaryMode dictonaryMode)
        {
            XmlDocument config = GetConfigAsXml();
            XmlAttribute? xmlAttribute = config.SelectSingleNode("configuration/appSettings/DictonaryMode")?.Attributes?["value"];
            if (xmlAttribute != null)
            {
                xmlAttribute.Value = dictonaryMode.ToString();
                config.Save(ConfigPath);
            }
        }

        public static void SetTestDatabaseConnectionString(string connectionString)
        {
            XmlDocument config = GetConfigAsXml();
            XmlAttribute? xmlAttribute = config.SelectSingleNode("configuration/connectionStrings/TDMTEST")?.Attributes?["connectionString"];
            if (xmlAttribute != null)
            {
                xmlAttribute.Value = connectionString;
                config.Save(ConfigPath);
            }
        }

        public static void SetProdDatabaseConnectionString(string connectionString)
        {
            XmlDocument config = GetConfigAsXml();
            XmlAttribute? xmlAttribute = config.SelectSingleNode("configuration/connectionStrings/TDMPROD")?.Attributes?["connectionString"];
            if (xmlAttribute != null)
            {
                xmlAttribute.Value = connectionString;
                config.Save(ConfigPath);
            }
        }

        public static DictonaryMode GetDictonaryMode()
        {
            XmlDocument config = GetConfigAsXml();
            string? dictonaryModeString = config.SelectSingleNode("configuration/appSettings/DictonaryMode")?.Attributes?["value"]?.Value;
            DictonaryMode dictonaryMode = Enum.Parse<DictonaryMode>(dictonaryModeString ?? "Global");
            return dictonaryMode;
        }

        public static void SetSettingsPassPhrase(string passPhrase)
        {
            XmlDocument config = GetConfigAsXml();
            XmlAttribute? xmlAttribute = config.SelectSingleNode("configuration/appSettings/SettingsPassPhrase")?.Attributes?["value"];
            if (xmlAttribute != null)
            {
                xmlAttribute.Value = passPhrase;
                config.Save(ConfigPath);
            }
        }

        public static void SetGlobalDictonaryPath(string path)
        {
            XmlDocument config = GetConfigAsXml();
            XmlAttribute? xmlAttribute = config.SelectSingleNode("configuration/appSettings/GlobalDictonaryRelativePath")?.Attributes?["value"];
            if (xmlAttribute != null)
            {
                xmlAttribute.Value = path;
                config.Save(ConfigPath);
            }
        }

        public static void SetLocalDictonaryPath(string path)
        {
            XmlDocument config = GetConfigAsXml();
            XmlAttribute? xmlAttribute = config.SelectSingleNode("configuration/appSettings/LocalDictonaryAbsolutePath")?.Attributes?["value"];
            if (xmlAttribute != null)
            {
                xmlAttribute.Value = path;
                config.Save(ConfigPath);
            }
        }
    }
}
