// See https://aka.ms/new-console-template for more information
using DeepCloning;
using System.Xml.Serialization;

var data = InitData();
CloneBinnary(data);

void CloneBinnary(List<Department> departments)
{
    var clone = ObjectCopier.Clone(departments);
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