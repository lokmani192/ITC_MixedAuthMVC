using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVC.Constants
{
    public class Constants
    {
        public static bool IsWindowsAuthentionEnabled { get { return Convert.ToBoolean(GetConfigurationValue("IsWindowsAuthenticationEnabled")); } }
        public static bool IsFormsAuthenticationEnabled { get { return Convert.ToBoolean(GetConfigurationValue("IsFormsAuthenticationEnabled")); } }

        public static string GetConfigurationValue(string configKey)
        {
            return ConfigurationManager.AppSettings[configKey];

        }
    }
}