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
   public class GetPaymentpolicyresponse
    {
    public CategoryType[] categoryTypes { get; set; }
    public Deposit deposit { get; set; }
    public string description { get; set; }
    public TimeDuration fullPaymentDueIn { get; set; }
    public bool immediatePay { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public MarketplaceIdEnum marketplaceId { get; set; }
    public string name { get; set; }
    public string paymentInstructions { get; set; }
    public PaymentMethod[] paymentMethods { get; set; }
    public string paymentPolicyId { get; set; }
    }
}
