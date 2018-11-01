using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
    {
 public   class BulkUpdatePriceQualityRequest
        {
     public PriceQuality[] requests { get; set; }
        }
    }
