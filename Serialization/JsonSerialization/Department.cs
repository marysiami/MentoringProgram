using System.Text.Json.Serialization;

namespace JsonSerialization
{
    public class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        [JsonConstructor] 
        public Department() { }

        public Department(string name, List<Employee> list)
        {
            DepartmentName = name;
            Employees = list;
        }

    }
}
