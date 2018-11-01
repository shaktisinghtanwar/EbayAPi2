using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
   public  class GetPromotionSummaryReportResponse
    {
       
    public Amount baseSale { get; set; }
    public string lastUpdated { get; set; }
    public string percentageSalesLift { get; set; }
    public Amount  promotionSale { get; set; }
    public Amount  totalSale { get; set; }
    }
}
