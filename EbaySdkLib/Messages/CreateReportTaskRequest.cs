using EbaySdkLib.Enums;
using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
 public class CreateReportTaskRequest
    {
        public string[] campaignIds { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
        public Dimension[] dimensions { get; set; }
        public InventoryReference[] inventoryReferences { get; set; }
        public string[] listingIds { get; set; }
        public MarketplaceIdEnum marketplaceId { get; set; }
        public string[] metricKeys { get; set; }
        public ReportFormatEnum reportFormat { get; set; }
        public ReportTypeEnum reportType { get; set; }
    }
}
