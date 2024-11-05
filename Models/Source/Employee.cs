using AutoMapperInDotnet.Models.AutoMapper.IgnoreMultiple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperInDotnet.Models.Source
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [NoMap]
        public string Address { get; set; }
        [NoMap]
        public string Email { get; set; }
    }
}
