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
   public class CreateorReplaceItemResponse
    {
        public Availability availability { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ConditionEnum condition { get; set; }
        public Aspect aspects { get; set; }
        public Product[] product { get; set; }

    }
}
