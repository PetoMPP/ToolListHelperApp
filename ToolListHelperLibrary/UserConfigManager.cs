using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperLibrary
{
    public class UserConfigManager
    {
        private const string ApplicationThemeConfigName = "ApplicationTheme";
        private static Configuration GetUserConfig()
        {
            return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
        }
        public static ApplicationTheme GetUserCurrentTheme()
        {
            Configuration userConfig = GetUserConfig();
            return Enum.Parse<ApplicationTheme>(userConfig.GetSection(ApplicationThemeConfigName).ToString() ?? ApplicationTheme.Light.ToString());
        }
    }
}
