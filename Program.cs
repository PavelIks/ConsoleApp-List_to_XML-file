using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ListXML
{
    public class Program
    {
        public class Department
        {
            public int ID { get; set; }
            public String Name { get; set; }
            public Employee LeaderOfDepartment { get; set; }
            public List<Employee> employees { get; set; } = new List<Employee>();
        }

        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Position { get; set; }
            public DateTime DOB { get; set; }
            public string Gender { get; set; }
            public double Salary { get; set; }
            public string Department { get; set; }
            public string EmpType { get; set; }
        }

        static void Main()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { ID = 11, Name = "Tom", DOB = new DateTime(1980, 10, 15), Salary =
                15000, Department = "Developers" },

                new Employee() { ID = 111, Name = "John", DOB = new DateTime(1985, 10, 15), Salary =
                1100, Department = "Developers" },

                new Employee() { ID = 90, Name = "David", DOB = new DateTime(1987, 10, 15), Salary =
                15000, Department = "Designers" },

                new Employee() { ID = 49, Name = "Pall", DOB = new DateTime(1989, 10, 15), Salary =
                3000, Department = "Developers" },

                new Employee() { ID = 97, Name = "Bill", DOB = new DateTime(1977, 10, 15), Salary =
                9700, Department = "Developers" },

                new Employee() { ID = 111, Name = "John", DOB = new DateTime(1977, 10, 15), Salary =
                1100, Department = "Managers" }
            };

            List<Department> departments = new List<Department>()
            {
                new Department() { ID = 1, Name= "Developers" },
                new Department() { ID = 2, Name = "Designers"},
                new Department() { ID = 3, Name = "Managers"}
            };

            XmlSerializer xmlDepart = new XmlSerializer(typeof(List<Department>));

            using (FileStream go = new FileStream(@"C:\Users\Pavlo\source\repos\ListXML\bin\Debug\File.xml", FileMode.OpenOrCreate))
            {
                xmlDepart.Serialize(go, departments);
            }
            /*using (FileStream go = new FileStream(@"C:\Users\Pavlo\source\repos\ListXML\bin\Debug\File.xml", FileMode.OpenOrCreate))
            {
                List<Department> dep2 = (List<Department>)xmlDepart.Deserialize(go);
            }*/
        }
    }
}