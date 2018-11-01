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
    public class CreateInventoryLocationRequest
        {
        public Location location { get; set; }
        public string locationAdditionalInformation { get; set; }
        public string locationInstructions { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        //public StoreTypeEnum locationTypes { get; set; }
        public string locationWebUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusEnum merchantLocationStatus { get; set; }
        public string name { get; set; }
        public OperatingHour[] operatingHours { get; set; }
        public string phone { get; set; }
        public SpecialHour[] specialHours { get; set; }
        }
    }
