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
   public class PickupAtLocationAvailability
        {
       [JsonConverter(typeof(StringEnumConverter))]
       public AvailabilityTypeEnum availability { get; set; }
        public  TimeDuration fulfillmentTime { get; set; }
        public string merchantLocationKey { get; set; }
        public int? quantity { get; set; }
        }
    }
