using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class MetricMetadata
    {
        public DataTypeEnum dataType { get; set; }
        public string metricKey { get; set; }
    }
}
