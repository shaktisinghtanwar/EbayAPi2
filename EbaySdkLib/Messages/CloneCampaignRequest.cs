using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
   public  class CloneCampaignRequest
    {
        public string campaignName { get; set; }
        public string endDate { get; set; }
        public FundingStrategy fundingStrategy { get; set; }
        public string startDate { get; set; }
    }
}
