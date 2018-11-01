using EbaySdkLib.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
    public class GetofferResponse
        {
        public int availableQuantity { get; set; }
        public string categoryId { get; set; }
        public string listingDescription { get; set; }
        public ListingPolicies listingPolicies { get; set; }
        public string merchantLocationKey { get; set; }
        public PricingSummary pricingSummary { get; set; }
        public string quantityLimitPerBuyer { get; set; }
        public Tax tax { get; set; }
        public string[] storeCategoryNames { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public FormatTypeEnum format { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MarketplaceIdEnum marketplaceId { get; set; }
        public string sku { get; set; }
        public string offerId { get; set; }
        public Listing listing { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusEnum status { get; set; }
        }
    }
