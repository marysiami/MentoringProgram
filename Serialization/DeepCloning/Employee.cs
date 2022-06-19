namespace DeepCloning
{
    [Serializable]
    public class Employee
    {
        public string EmployeeName { get; set; }

        public Employee (string name)
        {
            EmployeeName = name;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Employee p = (Employee)obj;
                return (EmployeeName == p.EmployeeName);
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(EmployeeName.GetHashCode());
        }
    }
}
