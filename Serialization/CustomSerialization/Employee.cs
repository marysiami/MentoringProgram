using System.Runtime.Serialization;

namespace CustomSerialization
{
    [Serializable]
    public class Employee : ISerializable
    {
        private readonly string _Name;
        private readonly int _Age;

        public string Name { get { return _Name; } }
              
        public int Age { get { return _Age; } }

        public Employee(string name, int employeeAge)
        {
            _Name = name;
            _Age = employeeAge;  
        }

        protected Employee(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            var name = info.GetString("Name");

            _Name = name ?? string.Empty;

            _Age = info.GetInt32("Age");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("Name", Name);
            info.AddValue("Age", Age);
        }
    }
}
