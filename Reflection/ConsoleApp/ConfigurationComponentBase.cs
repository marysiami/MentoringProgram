using Attributes;
using Providers;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleApp
{
    public abstract class ConfigurationComponentBase
    {
        private ConfigurationManagerConfigurationProvider CMProvider;
        private FileConfigurationProvider FileProvider;
        public ConfigurationComponentBase()
        {
            CMProvider = new ConfigurationManagerConfigurationProvider();
            FileProvider= new FileConfigurationProvider();
        }
        protected T GetValue<T>()
        {
            try
            {
                StackTrace stackTrace = new();
                MethodBase callingMethod = stackTrace.GetFrame(1).GetMethod();
                var attribute = this.GetType().GetProperty(callingMethod.Name.Replace("get_", String.Empty))?.GetCustomAttributes(typeof(ConfigurationItemAttribute), true).FirstOrDefault();
                if (attribute == null)
                {
                    throw new Exception("The attribute was not found.");
                }

                var confItemAttribute = (ConfigurationItemAttribute)attribute;

                if (string.IsNullOrEmpty(confItemAttribute.SettingName))
                    throw new Exception();

                string result;
                if (confItemAttribute.ProviderType == ProviderTypeEnum.File)
                {
                    result = FileProvider.LoadSettings(confItemAttribute.SettingName);
                }
                else
                {
                    result = CMProvider.LoadSettings(confItemAttribute.SettingName);
                }

                return (T)Convert.ChangeType(result, typeof(T));
            }
            catch (Exception e)
            {
                throw new Exception("GetValue exception", e);
            }
        }

        protected void SetValue<T>(T value)
        {            
            try
            {
                StackTrace stackTrace = new();
                MethodBase callingMethod = stackTrace.GetFrame(1).GetMethod();
                var attribute = this.GetType().GetProperty(callingMethod.Name.Replace("set_", String.Empty))?.GetCustomAttributes(typeof(ConfigurationItemAttribute), true).FirstOrDefault();
                if (attribute == null)
                {
                    throw new Exception("The attribute was not found.");
                }

                var confItemAttribute = (ConfigurationItemAttribute)attribute;    

                if (string.IsNullOrEmpty(confItemAttribute.SettingName))
                    throw new InvalidDataException("attribute.SettingName is null or empty");

                if(value == null)
                    throw new ArgumentNullException("Value param is null");

                if (confItemAttribute.ProviderType == ProviderTypeEnum.File)
                {
                    FileProvider.SaveSettings(confItemAttribute.SettingName, value);
                }
                else
                {
                    CMProvider.SaveSettings(confItemAttribute.SettingName, value);
                }
            }
            catch (Exception e)
            {
                throw new Exception("SetValue exception", e);
            }
        }
    }
}
