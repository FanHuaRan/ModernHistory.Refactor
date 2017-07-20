using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Utils
{
    /// <summary>
    /// 配置文件辅助类
    /// </summary>
    public class ConfigHelper
    {
        private static object locker = 1;
        private static ExeConfigurationFileMap ConfigFileMap = null;
        private static Configuration config = null;

        public static void UpdateAppConfig(string newKey, string newValue)
        {
            lock (locker)
            {
                if (config == null)
                {
                    IniConfiguration();
                } config.AppSettings.Settings[newKey].Value = newValue;
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        public static string ReadAppConfig(string Key)
        {
            string result = "";
            try
            {
                lock (locker)
                {
                    if (config == null)
                    {
                        IniConfiguration();
                    }
                }
                result = config.AppSettings.Settings[Key].Value;
            }
            catch (Exception)
            { }
            return result;
        }

        private static string GetConfigFile()
        {
                  // return Application.ExecutablePath + ".Config";
                //  HttpContext.Current.Server.MapPath("~/App_Data");
                  return "config";
        }

        private static void IniConfiguration()
        {
            ConfigFileMap = new ExeConfigurationFileMap();
            ConfigFileMap.ExeConfigFilename = GetConfigFile();
            config = ConfigurationManager.OpenMappedExeConfiguration(ConfigFileMap, ConfigurationUserLevel.None);
        }
    }
}
