using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbaySdkLib.Models
    {
    public class Dimensions
        {
        public int? height { get; set; }
        public int? length { get; set; }
        public LengthUnitOfMeasureEnum unit { get; set; }
        public string width { get; set; }
        }
    }
