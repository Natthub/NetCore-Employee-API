using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Employee_API.Model
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public float Salary { get; set; }
        public DateTime DateJoin { get; set; }

    }
}
