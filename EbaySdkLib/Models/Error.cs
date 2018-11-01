using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class Error
    {
        public string category { get; set; }
        public string domain { get; set; }
        public string errorId { get; set; }
        public List<string> inputRefIds { get; set; }
        public string longMessage { get; set; }
        public string message { get; set; }
        public List<string> outputRefIds { get; set; }
        public List<Parameter> parameters { get; set; }
        public string subdomain { get; set; }
    }
}
