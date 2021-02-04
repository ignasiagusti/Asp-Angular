using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPex1.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public float Salary { get; set; }

        public Employee()
        {
            Id = 0;
            Name = "";
            Surname = "";
            Position = "";
            Salary = 0;
        }
    }
}
