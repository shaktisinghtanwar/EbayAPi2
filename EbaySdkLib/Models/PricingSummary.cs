using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
    public class PricingSummary
        {
        public Amount minimumAdvertisedPrice { get; set; }
        public MinimumAdvertisedPriceHandlingEnum pricingVisibility { get; set; }
        public SoldOnEnum originallySoldForRetailPriceOn { get; set; }
        public Amount originalRetailPrice { get; set; }
        public Amount price { get; set; }

        }
    }
