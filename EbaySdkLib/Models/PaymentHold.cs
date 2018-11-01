using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
   public  class PaymentHold
    {
        public string expectedReleaseDate { get; set; }
        public Amount holdAmount { get; set; }
        public string holdReason { get; set; }
        public string holdState { get; set; }
        public string releaseDate { get; set; }
        public List<SellerActionsToRelease> sellerActionsToRelease { get; set; }
    }
}
