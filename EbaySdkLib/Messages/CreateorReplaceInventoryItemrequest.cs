using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EbaySdkLib.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EbaySdkLib.Messages
{
   public class CreateorReplaceInventoryItemrequest
       {
       public Availability availability { get; set; }
       [JsonConverter(typeof(StringEnumConverter))]
       public ConditionEnum condition { get; set; }
       public string conditionDescription { get; set; }
       public PackageWeightAndSize packageWeightAndSize { get; set; }
       public Product product { get; set; }
       public string sku { get; set; }
       public string[] groupIds { get; set; }

    }
}
