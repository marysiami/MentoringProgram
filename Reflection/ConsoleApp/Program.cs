// See https://aka.ms/new-console-template for more information
using ConsoleApp;
using System.Reflection;

try
{
    Assembly pluginAssembly = LoadPlugin("../Reflection/CMProviderPlugin/bin/Debug/net6.0/CMProviderPlugin.dll");
    var cMProvider =  CreateCommands(pluginAssembly).FirstOrDefault();

    pluginAssembly = LoadPlugin("../Reflection/FileProviderPlugin/bin/Debug/net6.0/FileProviderPlugin.dll");
    var fileProvider = CreateCommands(pluginAssembly).FirstOrDefault();

    if(cMProvider != null && fileProvider != null)
    {
        var component = new ConfigurationComponentExample(cMProvider, fileProvider)
        {
            TestSettingInt = 1234,
            TestSettingString = "abcdef",
            TestSettingDateTime = DateTime.Now,
            TestSettingFloat = float.MaxValue
        };

        Console.WriteLine("TestSettingInt: {0}", component.TestSettingInt);
        Console.WriteLine("TestSettingString: {0}", component.TestSettingString);
        Console.WriteLine("TestSettingDateTime: {0}", component.TestSettingDateTime);
        Console.WriteLine("TestSettingFloat: {0}", component.TestSettingFloat);
    }
    else
    {
        throw new Exception("One provider is missing");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}




static Assembly LoadPlugin(string relativePath)
{
    // Navigate up to the solution root
    string root = Path.GetFullPath(Path.Combine(
        Path.GetDirectoryName(
            Path.GetDirectoryName(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(typeof(Program).Assembly.Location)))))));

    string pluginLocation = Path.GetFullPath(Path.Combine(root, relativePath.Replace('\\', Path.DirectorySeparatorChar)));
    Console.WriteLine($"Loading commands from: {pluginLocation}");
    PluginLoadContext loadContext = new PluginLoadContext(pluginLocation);
    return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
}

static IEnumerable<PluginBase.ICommandProvider> CreateCommands(Assembly assembly)
{
    int count = 0;

    foreach (Type type in assembly.GetTypes())
    {
        if (typeof(PluginBase.ICommandProvider).IsAssignableFrom(type))
        {
            PluginBase.ICommandProvider? result = Activator.CreateInstance(type) as PluginBase.ICommandProvider;
            if (result != null)
            {
                count++;
                yield return result;
            }
        }
    }

    if (count == 0)
    {
        string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
        throw new ApplicationException(
            $"Can't find any type which implements ICommand in {assembly} from {assembly.Location}.\n" +
            $"Available types: {availableTypes}");
    }
}