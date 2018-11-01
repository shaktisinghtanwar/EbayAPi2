using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
   public  class SelectionRule
    {

        public string[] brands { get; set; }
        public string[] categoryIds { get; set; }
        public CategoryScopeEnum categoryScope { get; set; }
        public string[] listingConditionIds { get; set; }
        public Amount maxPrice { get; set; }
        public Amount minPrice { get; set; }
    }
}
