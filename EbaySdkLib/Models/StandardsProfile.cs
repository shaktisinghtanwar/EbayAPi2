using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class StandardsProfile
    {
        public Cycle cycle { get; set; }
        public bool defaultProgram { get; set; }
        public string evaluationReason { get; set; }
        public Metric[] Metrics { get; set; }
        public ProgramEnum program { get; set; }
        public StandardsLevelEnum standardsLevel { get; set; }

    }
}
