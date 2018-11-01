using EbaySdkLib.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace EbaySdkLib.Messages
{
    public class CreateFulfillmentRequest
    {
        public CategoryType[] categoryTypes { get; set; }
        public string description { get; set; }
        public string freightShipping { get; set; }
        public string globalShipping { get; set; }
        public TimeDuration handlingTime { get; set; }
        public string localPickup { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public string marketplaceId { get; set; }
        public string name { get; set; }
        public string pickupDropOff { get; set; }
        public ShippingOption[] shippingOptions { get; set; }
        public RegionSet shipToLocations { get; set; }
    }
}
