using System.Xml.Serialization;

namespace XMLSerialization
{
    public class Department
    {
        [XmlElement(ElementName = "Name")]
        public string DepartmentName { get; set; }

        [XmlArray("TeamMembers")]
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Department() { }

        public Department(string name, List<Employee> list)
        {
            DepartmentName = name;
            Employees = list;
        }
    }
}
