using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class DimensionMetadata
    {
        public MetadataHeader metadataHeader { get; set; }
        public MetadataRecord[] metadataRecords { get; set; }

        public DataTypeEnum dataType { get; set; } 
        public string dimensionKey { get; set; }
        public DimensionKeyAnnotation[] dimensionKeyAnnotations { get; set; }
    }
}
