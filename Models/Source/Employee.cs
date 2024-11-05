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
        public string Department { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
