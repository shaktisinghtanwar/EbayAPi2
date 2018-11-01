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
   public  class FulfillmentStartInstruction
    {
        public bool ebaySupportedFulfillment { get; set; }
        public Address finalDestinationAddress { get; set; }
          [JsonConverter(typeof(StringEnumConverter))]
        public FulfillmentInstructionsTypeEnum    fulfillmentInstructionsType { get; set; }
        public string maxEstimatedDeliveryDate { get; set; }
        public string minEstimatedDeliveryDate { get; set; }
        public ShippingStep shippingStep { get; set; }
    }
}
