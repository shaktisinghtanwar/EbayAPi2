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
   public  class SalesTax
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCodeEnum countryCode { get; set; }
        public string salesTaxJurisdictionId { get; set; }
        public string salesTaxPercentage { get; set; }
        public  bool shippingAndHandlingTaxed { get; set; }
    }
}
