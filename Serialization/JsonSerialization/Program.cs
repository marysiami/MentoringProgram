// See https://aka.ms/new-console-template for more information
using JsonSerialization;
using System.Text.Json;

var data = InitData();

Serialize(data);
Deserialize();

static void Serialize(List<Department> departments)
{
    JsonSerializerOptions options = new JsonSerializerOptions();
    options.WriteIndented = true;
    options.IncludeFields = true;
    options.IgnoreReadOnlyProperties = false;

    string jsonString = JsonSerializer.Serialize(departments, options: options);

    File.WriteAllText("JsonData.txt", jsonString);
}

static void Deserialize()
{
    var json = File.ReadAllText("JsonData.txt");
   
    var departments = JsonSerializer.Deserialize<List<Department>>(json);
    foreach (var department in departments)
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


