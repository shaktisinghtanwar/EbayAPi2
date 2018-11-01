using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
   public  class ShippingStep
    {
        public string shippingCarrierCode { get; set; }
        public string shippingServiceCode { get; set; }
        public Contact shipTo { get; set; }
        public string shipToReferenceId { get; set; }
    }
}
