using AutoMapperInDotnet.Models.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperInDotnet.Models.Destination
{
    public class EmployeeDTO
    {
        public string FullName { get; set; }
        public int Salary { get; set; }      
        public string Department { get; set; }

        public Address Address { get; set; }
    }
}
