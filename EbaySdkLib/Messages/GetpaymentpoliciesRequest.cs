using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
 public  class GetpaymentpoliciesRequest
    {
     [JsonConverter(typeof(StringEnumConverter))]
     public string marketplaceId { get; set; }
    }
}
