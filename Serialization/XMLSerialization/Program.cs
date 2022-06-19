// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;
using XMLSerialization;

var data = InitData();

Serialize(data);
Deserialize();

static void Serialize(List<Department> departments)
{
    var serializer = new XmlSerializer(typeof(List<Department>));

    var writer = new StreamWriter("XMLData");

    serializer.Serialize(writer, departments);

    writer.Close();
}

static void Deserialize()
{

    var serializer = new XmlSerializer(typeof(List<Department>));

    var fs = new FileStream("XMLData", FileMode.Open);
    var departments = (List<Department>)serializer.Deserialize(fs);

    foreach (var department in departments)
    {
        Console.WriteLine($"Name {department.DepartmentName} Eployees: {department.Employees.Count}");

        foreach(var employee in department.Employees)
        {
            Console.WriteLine($" Employee Name: {employee.EmployeeName}");
        }
    }
}

static List<Department> InitData()
{
    var employees = new List<Employee>
    {
        new Employee("Anna"),
        new Employee("Rob"),
        new Employee("Steen")
    };

    var departments = new List<Department>
    {
        new Department("DepName", employees),
        new Department("DepName2", employees),
        new Department("DepName3", employees)
    };

    return departments;
}