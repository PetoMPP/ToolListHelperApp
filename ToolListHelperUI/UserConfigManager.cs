using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperUI
{
    public class UserConfigManager
    {
        public static ApplicationTheme GetCurrentUserTheme()
        {
            return Enum.Parse<ApplicationTheme>(Properties.Settings.Default.ApplicationTheme);
        }
        public static void SetCurrentUserTheme(ApplicationTheme applicationTheme)
        {
            Properties.Settings.Default.ApplicationTheme = applicationTheme.ToString();
        }
    }
}
