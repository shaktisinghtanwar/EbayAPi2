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
    public class FundingStrategy
    {

        public string bidPercentage { get; set; }
          [JsonConverter(typeof(StringEnumConverter))]
        public FundingModelEnum fundingModel { get; set; }
    }
}
