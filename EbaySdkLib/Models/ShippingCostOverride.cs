using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
    public class ShippingCostOverride
        {
        public Amount surcharge { get; set; }
        public Amount additionalShippingCost { get; set; }
        }
    }
