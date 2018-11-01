using EbaySdkLib.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
  public   class GetCampaignByNameResponse
    {
        public CampaignCriterion campaignCriterion { get; set; }
        public string campaignId { get; set; }
        public string campaignName { get; set; }
        public string campaignStatus { get; set; }
        public string endDate { get; set; }
        public FundingStrategy fundingStrategy { get; set; }

       [JsonConverter(typeof(StringEnumConverter))]
        public MarketplaceIdEnum marketplaceId { get; set; }
        public string startDate { get; set; }
    }
}
