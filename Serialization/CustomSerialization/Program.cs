using CustomSerialization;
using ProtoBuf;
using System.Runtime.Serialization.Formatters.Binary;

var data = InitData();
var daraProto = InitDataProto();
Serialize(data, daraProto);
Deserialize();

void Serialize(List<Employee> employees, List<EmployeeProto> employeeProto)
{
    using (var file = File.Create("CustomSerializationProto.bin"))
    {
        Serializer.Serialize(file, employeeProto);
    }

    using (var file = File.Create("CustomSerialization.bin"))
    {
        BinaryFormatter formatter = new ();
        formatter.Serialize(file, employees);   
    }

}

void Deserialize()
{
    var employees = new List<Employee>();
    var employeesProto = new List<EmployeeProto>();

    using (var file = File.OpenRead("CustomSerializationProto.bin"))
    {
        employeesProto = Serializer.Deserialize<List<EmployeeProto>>(file);
    }

    Console.WriteLine($"Proto-buf RESULT: ");

    foreach (var e in employeesProto)
    {
        Console.WriteLine($"Name {e.Name} Age: {e.Age}");       
    }

    using (var file = File.OpenRead("CustomSerialization.bin"))
    {
        BinaryFormatter formatter = new();
        employees = (List<Employee>)formatter.Deserialize(file);
    }

    Console.WriteLine($"BINARY RESULT: ");

    foreach (var e in employees)
    {
        Console.WriteLine($"Name {e.Name} Age: {e.Age}");
    }
}

List<Employee> InitData()
{
    var employees = new List<Employee>
    {
        new Employee("Anna", 22),
        new Employee("Rob", 33),
        new Employee("Steen", 45)
    };

    return employees;
}

List<EmployeeProto> InitDataProto()
{
    var employees = new List<EmployeeProto>
    {
        new EmployeeProto("Anna", 22),
        new EmployeeProto("Rob", 33),
        new EmployeeProto("Steen", 45)
    };

    return employees;
}