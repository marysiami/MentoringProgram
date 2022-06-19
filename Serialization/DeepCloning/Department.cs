namespace DeepCloning
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

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Department d = (Department)obj;
                return (DepartmentName == d.DepartmentName && Employees.SequenceEqual(d.Employees));
            }
          
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(DepartmentName.GetHashCode(), Employees.GetHashCode());
        }
    }
}
