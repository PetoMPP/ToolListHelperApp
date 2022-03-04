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
            string connectionString = ConfigurationManager.ConnectionStrings["TDM PROD"].ConnectionString;
            return timeout switch
            {
                15 => connectionString,
                _ => connectionString + (connectionString.EndsWith(";") ? $"Connection Timeout={timeout}" : $";Connection Timeout={timeout}")
            };
        }
    }
}
