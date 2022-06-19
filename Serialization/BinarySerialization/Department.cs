namespace BinarySerialization
{
    [Serializable]
    public class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Department(string name, List<Employee> list)
        {
            DepartmentName = name;
            Employees = list;
        }
    }
}
