using EbaySdkLib.Enums;
using EbaySdkLib.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
    {
   public class CreateOffersRequest
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
        public string sku { get; set; }
       [JsonConverter(typeof(StringEnumConverter))]
        public MarketplaceIdEnum marketplaceId { get; set; }
       public FormatTypeEnum format { get; set; }
        }
    }
