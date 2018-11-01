using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
      public  class DiscountRule
        {
        public DiscountBenefit discountBenefit { get; set; }
        public DiscountSpecification discountSpecification { get; set; }
        public int  ruleOrder { get; set; }
    }
}
