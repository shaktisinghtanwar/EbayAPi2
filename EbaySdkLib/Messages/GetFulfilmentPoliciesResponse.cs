using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbaySdkLib.Messages
{
    public class GetFulfilmentPoliciesResponse
    {

        public List<FulfillmentPolicy> fulfillmentPolicies { get; set; }
        public string href { get; set; }
        public string limit { get; set; }
        public string next { get; set; }
        public string offset { get; set; }
        public string prev { get; set; }
        public string total { get; set; }
    }

   
}
