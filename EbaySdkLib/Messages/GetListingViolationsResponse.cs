using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
   public class GetListingViolationsResponse
    {
        public int offset { get; set; }
        public string href { get; set; }
        public int total { get; set; }
        public string next { get; set; }
        public string prev { get; set; }
        public int limit { get; set; }
        public ListingViolation[] listingViolations { get; set; }
    }
}
