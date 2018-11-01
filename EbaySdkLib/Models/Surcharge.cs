using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EbaySdkLib.Models
{
    public class Surcharge
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCodeEnum currency { get; set; }
        public string value { get; set; }
    }
}
