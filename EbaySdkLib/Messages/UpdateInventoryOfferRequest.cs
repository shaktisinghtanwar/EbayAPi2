using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
    {
   public class UpdateInventoryOfferRequest
        {
        public int? availableQuantity { get; set; }
        public string categoryId { get; set; }
        public string listingDescription { get; set; }
        public ListingPolicies listingPolicies { get; set; }
        public string merchantLocationKey { get; set; }
        public PricingSummary pricingSummary { get; set; }
        public int? quantityLimitPerBuyer { get; set; }
        public Tax tax { get; set; }
        public string[] storeCategoryNames { get; set; }
        }
    }
