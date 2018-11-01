using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class MetadataHeader
    {
        public string key { get; set; }
        public DimensionKey[] metadataKeys { get; set; }
    }

}
