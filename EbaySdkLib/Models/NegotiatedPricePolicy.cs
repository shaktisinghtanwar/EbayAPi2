using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
    public class NegotiatedPricePolicy
        {
        public bool bestOfferAutoAcceptEnabled { get; set; }
        public bool bestOfferAutoDeclineEnabled { get; set; }
        public bool bestOfferCounterEnabled { get; set; }
        public string categoryId { get; set; }
        public string categoryTreeId { get; set; }
        }
    }
