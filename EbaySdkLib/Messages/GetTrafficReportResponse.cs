using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
   public class GetTrafficReportResponse
    {
        public DimensionMetadata[] dimensionMetadata { get; set; }
        public string endDate { get; set; }
        public Header header { get; set; }
        public string lastUpdatedDate { get; set; }
        public Record[] records { get; set; }
        public string startDate { get; set; }
        public Warnings[] warnings { get; set; }
    }
}
