namespace PluginBase
{
    public interface ICommandProvider
    {
        void SaveSettings<T>(string key, T value);
        string LoadSettings(string key);
    }
}
