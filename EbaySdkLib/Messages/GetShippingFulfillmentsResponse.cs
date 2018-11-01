using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
   public  class GetShippingFulfillmentsResponse
    {

       public List<ShippingFulfillment> fulfillments { get; set; }
        public int  total { get; set; }
        public List<Warnings> warnings { get; set; }
    }
}
