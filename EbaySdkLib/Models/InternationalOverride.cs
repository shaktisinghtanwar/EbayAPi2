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
    public class InternationalOverride
        {
        [JsonConverter(typeof(StringEnumConverter))]
        public ReturnMethodEnum returnMethod { get; set; }
        public TimeDuration returnPeriod { get; set; }
        public bool  returnsAccepted { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ReturnShippingCostPayerEnum returnShippingCostPayer { get; set; }
        }

    }
