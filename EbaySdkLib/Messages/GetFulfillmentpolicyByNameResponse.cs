using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
   public  class GetFulfillmentpolicyByNameResponse
    {

        public List<CategoryType> categoryTypes { get; set; }
        public string description { get; set; }
        public string freightShipping { get; set; }
        public string fulfillmentPolicyId { get; set; }
        public string globalShipping { get; set; }
        public TimeDuration handlingTime { get; set; }
        public string localPickup { get; set; }
        public string marketplaceId { get; set; }
        public string name { get; set; }
        public string pickupDropOff { get; set; }
        public List<ShippingOption> shippingOptions { get; set; }
        public RegionSet shipToLocations { get; set; }
    }
}
