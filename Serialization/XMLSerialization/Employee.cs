using System.Xml.Serialization;

namespace XMLSerialization
{
    public class Employee
    {
        [XmlElement(ElementName = "FirstName")]
        public string EmployeeName { get; set; }

        public Employee() { }

        public Employee(string name)
        {
            EmployeeName = name;
        }
    }
}
