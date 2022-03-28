using System.Configuration;

namespace Providers
{
    public static class FileConfigurationProvider
    {
        public static void SaveSettings<T>(string key, T value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value?.ToString());
                }
                else
                {
                    settings[key].Value = value?.ToString();
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException err)
            {
                throw new ConfigurationErrorsException("Error writing app settings", err);                
            }
        }

        public static string LoadSettings(string key)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                string result = settings[key].Value ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException err)
            {
                throw new ConfigurationErrorsException("Error reading app settings", err);
            }
        }
    }
}
