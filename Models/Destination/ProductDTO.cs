using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperInDotnet.Models.Destination
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public int Amount { get; set; }
    }
}
