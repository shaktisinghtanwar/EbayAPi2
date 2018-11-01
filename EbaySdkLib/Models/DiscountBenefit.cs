using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
   public  class DiscountBenefit
    {
        public Amount amountOffItem { get; set; }
        public Amount amountOffOrder { get; set; }
        public string percentageOffItem { get; set; }
        public string percentageOffOrder { get; set; }
    }
}
