using EbaySdkLib.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EbaySdkLib.Models
{
   public  class RateTable
    {
       [JsonConverter(typeof(StringEnumConverter))]
       public CountryCodeEnum countryCode { get; set; }
       [JsonConverter(typeof(StringEnumConverter))]
       public ShippingOptionTypeEnum optionType { get; set; }
        public string locality { get; set; }
        public string name { get; set; }
        public string rateTableId { get; set; }
    }
}
