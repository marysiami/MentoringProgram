// See https://aka.ms/new-console-template for more information

using BinarySerialization;
using System.Runtime.Serialization.Formatters.Binary;

var data = InitData();

Serialize(data);
Deserialize();

static void Serialize(List<Department> departments)
{
    Stream ms = File.OpenWrite("BinaryData");
    BinaryFormatter formatter = new BinaryFormatter();
    formatter.Serialize(ms, departments);
    ms.Flush();
    ms.Close();
    ms.Dispose();
}

static void Deserialize()
{
    BinaryFormatter formatter = new BinaryFormatter();

    FileStream fs = File.Open("BinaryData", FileMode.Open);

    object obj = formatter.Deserialize(fs);
    var depList = (List<Department>)obj;
    fs.Flush();
    fs.Close();
    fs.Dispose();

    Console.WriteLine($"BINARY RESULT: ");

    foreach (var department in depList)
    {
        Console.WriteLine($"Name {department.DepartmentName} Eployees: {department.Employees.Count}");

        foreach (var employee in department.Employees)
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