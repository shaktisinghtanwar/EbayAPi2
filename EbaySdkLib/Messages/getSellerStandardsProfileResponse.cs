using EbaySdkLib.Enums;
using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
  public  class getSellerStandardsProfileResponse
    {
        public Cycle cycle { get; set; }
        public string defaultProgram { get; set; }
        public string evaluationReason { get; set; }
        public List<Metric> metrics { get; set; }
        public ProgramEnum program { get; set; }
        public string standardsLevel { get; set; }
    }
}
