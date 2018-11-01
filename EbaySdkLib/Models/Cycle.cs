using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class Cycle
    {
        public CycleTypeEnum cycleType { get; set; } 
        public string evaluationDate { get; set; }
        public string evaluationMonth { get; set; }
    }
}
