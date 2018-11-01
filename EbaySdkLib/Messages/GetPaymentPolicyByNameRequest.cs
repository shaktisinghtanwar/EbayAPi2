using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
public    class GetPaymentPolicyByNameRequest
    {
    public string name { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public Models.MarketplaceIdEnum marketplaceId { get; set; }
    }
}
