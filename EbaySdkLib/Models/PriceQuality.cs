using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbaySdkLib.Models
    {
    public class PriceQuality
        {
        public string sku { get; set; }
        public ShipToLocationAvailability shipToLocationAvailability { get; set; }
        public Offer[] offers { get; set; }
        }

    }
