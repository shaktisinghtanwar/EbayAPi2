using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
  public  class Availability
        {
        public PickupAtLocationAvailability[] pickupAtLocationAvailability { get; set; }
        public ShipToLocationAvailability shipToLocationAvailability { get; set; }
        }
    }
