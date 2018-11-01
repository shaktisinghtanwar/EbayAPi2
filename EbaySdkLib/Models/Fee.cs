using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
    public class Fee
        {
        public string feeType { get; set; }
        public Amount amount { get; set; }
        public Amount promotionalDiscount { get; set; }
        }
    }
