using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace EbaySdkLib.Models
{
    public class ShippingOption
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ShippingCostTypeEnum costType { get; set; }
        public Amount insuranceFee { get; set; }
        public string insuranceOffered { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ShippingOptionTypeEnum optionType { get; set; }
        public Amount packageHandlingCost { get; set; }
        public string rateTableId { get; set; }
        public ShippingService[] shippingServices { get; set; }
    }
}
