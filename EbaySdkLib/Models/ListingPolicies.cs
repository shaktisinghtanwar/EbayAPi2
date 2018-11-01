using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
    public class ListingPolicies
        {
        public string paymentPolicyId { get; set; }
        public string returnPolicyId { get; set; }
        public ShippingCostOverride[] shippingCostOverrides { get; set; }
        }
    }