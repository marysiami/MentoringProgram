using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace JsonSerialization
{
    public class Employee
    {
        [JsonProperty(Required = Required.Always)]
        public string EmployeeName { get; set; }

        [System.Text.Json.Serialization.JsonConstructor]
        public Employee() { }

        public Employee(string name)
        {
            EmployeeName = name;
        }
    }
}
