using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperInDotnet.Models.Source
{
    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public Address Address { get; set; }
        public string Department { get; set; }
    }
}
