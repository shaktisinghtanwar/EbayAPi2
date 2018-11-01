using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EbaySdkLib.Models
{
    public class CashOnDeliveryFee
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCodeEnum currency { get; set; }
        public string value { get; set; }
    }
}
