using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
  
        public class Deposit
            {
            public Amount amount { get; set; }
            public DueIn dueIn { get; set; }
            public PaymentMethod paymentMethods { get; set; }
            }

    
}
