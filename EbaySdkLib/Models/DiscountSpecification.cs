using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
   public  class DiscountSpecification
    {
        public Amount forEachAmount { get; set; }
        public int forEachQuantity { get; set; }
        public Amount minAmount { get; set; }
        public int  minQuantity { get; set; }
        public int  numberOfDiscountedItems { get; set; }
    }
}
