using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Enums
{
  public   class PaymentSummary
    {
        public List<Payment> payments { get; set; }
        public List<OrderRefund> refunds { get; set; }
        public Amount  totalDueSeller { get; set; }
    }
}
