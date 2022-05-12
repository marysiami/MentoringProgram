using System.Text.Json.Serialization;

namespace JsonSerialization
{
    public class Employee
    {
        public string EmployeeName { get; set; }

        [JsonConstructor]
        public Employee() { }

        public Employee(string name)
        {
            EmployeeName = name;
        }
    }
}
