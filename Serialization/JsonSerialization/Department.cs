using Newtonsoft.Json;

namespace JsonSerialization
{
    public class Department
    {
        [JsonProperty(Required = Required.Always)]
        public string DepartmentName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<Employee> Employees { get; set; } = new List<Employee>();

        [System.Text.Json.Serialization.JsonConstructor] 
        public Department() { }

        public Department(string name, List<Employee> list)
        {
            DepartmentName = name;
            Employees = list;
        }

    }
}
