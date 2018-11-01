using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbaySdkLib.Messages
{
    public class GetFulfilmentPoliciesRequest
    {
        
        //[JsonConverter(typeof(StringEnumConverter))]
        public string marketplaceId { get; set; }
    }
}
