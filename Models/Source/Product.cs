using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperInDotnet.Models.Source
{
    public class Product
    {
        public int ProductID { get; set; } 
        public string Name { get; set; }
        public string OptionalName { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
    }
}
