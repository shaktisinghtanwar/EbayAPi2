using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
   public class GetReportMetadataResponse
    {
        public DimensionMetadata[] dimensionMetadata { get; set; }
        public string maxNumberOfDimensionsToRequest { get; set; }
        public string maxNumberOfMetricsToRequest { get; set; }
        public MetricMetadata[] metricMetadata { get; set; }
        public string reportType { get; set; }
    }
}
