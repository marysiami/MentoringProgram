using ProtoBuf;

namespace CustomSerialization
{
    [ProtoContract]
    public class EmployeeProto
    {
        public EmployeeProto()
        {
        }

        public EmployeeProto(string? name, int age)
        {
            Name = name;
            Age = age;
        }

        [ProtoMember(1)]
        public string? Name { get; set; }

        [ProtoMember(2)]
        public int Age { get; set; }
    }
}
