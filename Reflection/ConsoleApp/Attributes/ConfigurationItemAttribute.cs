using ConsoleApp;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    internal class ConfigurationItemAttribute : Attribute
    {
        private readonly string settingName;
        private readonly ProviderTypeEnum providerType;

        public ConfigurationItemAttribute(string settingName, ProviderTypeEnum providerType)
        {
            this.settingName = settingName;
            this.providerType = providerType;
        }
        
        public virtual string SettingName
        {
            get { return settingName; }
        }

        public virtual ProviderTypeEnum ProviderType
        {
            get { return providerType; }
        }
    }
}
