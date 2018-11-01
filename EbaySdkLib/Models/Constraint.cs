using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class Constraint
    {
        public AspectDataTypeEnum aspectDataType { get; set; }
        public string aspectFormat { get; set; }
        public AspectModeEnum aspectMode { get; set; }
        public bool aspectRequired { get; set; }
        public ItemToAspectCardinalityEnum productToAspectCardinality { get; set; }
    }
}
