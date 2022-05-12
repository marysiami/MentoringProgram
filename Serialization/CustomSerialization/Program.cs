using CustomSerialization;


var data = InitData();
Serialize(data);
Deserialize();

void Serialize(List<Department> departments)
{

}

void Deserialize()
{

   
}

List<Department> InitData()
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