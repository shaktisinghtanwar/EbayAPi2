using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class ReportTask
    {
        public List<string> campaignIds { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
        public Dimension[] dimensions { get; set; }
        public InventoryReference[] inventoryReferences { get; set; }
        public string[] listingIds { get; set; }
        public string marketplaceId { get; set; }
        public string[] metricKeys { get; set; }
        public string reportExpirationDate { get; set; }
        public string reportFormat { get; set; }
        public string reportHref { get; set; }
        public string reportId { get; set; }
        public string reportName { get; set; }
        public string reportTaskCompletionDate { get; set; }
        public string reportTaskCreationDate { get; set; }
        public string reportTaskExpectedCompletionDate { get; set; }
        public string reportTaskId { get; set; }
        public string reportTaskStatus { get; set; }
        public string reportTaskStatusMessage { get; set; }
        public string reportType { get; set; }
    }
}
