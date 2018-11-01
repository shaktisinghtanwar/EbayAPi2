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
    public class Address
    {

        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCodeEnum country { get; set; }
        public string county { get; set; }
        public string postalCode { get; set; }
        public string stateOrProvince { get; set; }
    }
}
