using Attributes;

namespace ConsoleApp
{
    public class ConfigurationComponentExample: ConfigurationComponentBase
    {
        [ConfigurationItem("settingsNameInt", ProviderTypeEnum.File)]
        public int TestSettingInt
        {
            get
            {
                return GetValue<int>();
            }
            set
            {
                SetValue(value);
            }
        }

        [ConfigurationItem("settingsNameString", ProviderTypeEnum.CM)]
        public string TestSettingString
        {
            get
            {
                return GetValue<string>();
            }
            set
            {
                SetValue(value);
            }
        }

        [ConfigurationItem("settingsNameFloat", ProviderTypeEnum.File)]
        public float TestSettingFloat
        {
            get
            {
                return GetValue<float>();
            }
            set
            {
                SetValue(value);
            }
        }

        [ConfigurationItem("settingsNameDateTime", ProviderTypeEnum.File)]
        public DateTime TestSettingDateTime
        {
            get
            {
                return GetValue<DateTime>();
            }
            set
            {
                SetValue(value);
            }
        }
    }
}
