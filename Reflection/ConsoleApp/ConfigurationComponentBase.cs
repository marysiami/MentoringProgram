using Attributes;
using Providers;

namespace ConsoleApp
{
    public abstract class ConfigurationComponentBase
    {
        protected T GetValue<T>()
        {
            var attribute = Attribute.GetCustomAttribute(typeof(T),typeof(ConfigurationItemAttribute));
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
                result = FileConfigurationProvider.LoadSettings(confItemAttribute.SettingName);
            }
            else
            {
                var provider = new ConfigurationManagerConfigurationProvider();
                result = provider.LoadSettings(confItemAttribute.SettingName);
            }

            return (T)Convert.ChangeType(result, typeof(T)); ;
        }

        protected void SetValue<T>(T value)
        {
            var attribute = Attribute.GetCustomAttribute(typeof(T), typeof(ConfigurationItemAttribute));
            if(attribute == null)
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
                FileConfigurationProvider.SaveSettings(confItemAttribute.SettingName, value);
            }
            else
            {
                var provider = new ConfigurationManagerConfigurationProvider();
                provider.SaveSettings(confItemAttribute.SettingName, value);
            }
        }
    }
}
