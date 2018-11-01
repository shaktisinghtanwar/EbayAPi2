using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
  public   class DeliveryCost
    {

        public Amount  importCharges { get; set; }
        public Amount  shippingCost { get; set; }
        public Amount  shippingIntermediationFee { get; set; }
    }
}
