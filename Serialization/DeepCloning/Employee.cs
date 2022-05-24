﻿namespace DeepCloning
{
    [Serializable]
    public class Employee
    {
        public string EmployeeName { get; set; }

        public Employee (string name)
        {
            EmployeeName = name;
        }
    }
}
