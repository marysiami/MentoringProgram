using System.Configuration;

namespace Providers
{
    public class ConfigurationManagerConfigurationProvider
    {
        private Configuration Config { get; set; }
        private CustomSection Section { get; set; }  

        public ConfigurationManagerConfigurationProvider()
        {
            Section = new CustomSection();

            Config = ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            if (Config.Sections["CustomSection"] == null)
            {
                Config.Sections.Add("CustomSection", Section);
            }
        }

        public void SaveSettings<T>(string key, T value)
        {
            try
            {
                Config.AppSettings.Settings.Add(key, value?.ToString());

                Section.SectionInformation.ForceSave = true;

                Config.Save(ConfigurationSaveMode.Full);

                Console.WriteLine("Created configuration file: {0}",
                    Config.FilePath);
            }
            catch (ConfigurationErrorsException err)
            {
               throw new ConfigurationErrorsException("CreateConfigurationFile: {0}", err);
            }
        }

        public string LoadSettings(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException err)
            {
                throw new ConfigurationErrorsException("Error reading app settings", err);
            }
        }

        public sealed class CustomSection : ConfigurationSection
        {
        }
    }
}
