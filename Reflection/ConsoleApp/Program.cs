// See https://aka.ms/new-console-template for more information
using ConsoleApp;

var component = new ConfigurationComponentExample();
component.TestSettingInt = 1234;
component.TestSettingString = "abcdef";
component.TestSettingDateTime = DateTime.Now;
component.TestSettingFloat = float.MaxValue;

Console.WriteLine("TestSettingInt: {0}", component.TestSettingInt);
Console.WriteLine("TestSettingString: {0}", component.TestSettingString);
Console.WriteLine("TestSettingDateTime: {0}", component.TestSettingDateTime);
Console.WriteLine("TestSettingFloat: {0}", component.TestSettingFloat);