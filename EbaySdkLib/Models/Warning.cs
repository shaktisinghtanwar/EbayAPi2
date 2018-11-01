using System.Collections.Generic;

namespace EbaySdkLib.Models
{
    public class Warning
    {
        public string category { get; set; }
        public string domain { get; set; }
        public string errorId { get; set; }
        public List<string> inputRefIds { get; set; }
        public string longMessage { get; set; }
        public string message { get; set; }
        public List<string> outputRefIds { get; set; }
        public List<ErrorParameterV3> parameters { get; set; }
        public string subdomain { get; set; }
    }

}
