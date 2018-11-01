using EbaySdkLib.Enums;
using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
   public  class GetSalesTaxResponse
    {

        public CountryCodeEnum  countryCode { get; set; }
        public string salesTaxJurisdictionId { get; set; }
        public string salesTaxPercentage { get; set; }
        public bool shippingAndHandlingTaxed { get; set; }
    }
}
