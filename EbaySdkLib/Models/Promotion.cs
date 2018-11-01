using EbaySdkLib.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class Promotion
    {
        public string description { get; set; }
        public string endDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MarketplaceIdEnum marketplaceId { get; set; }
        public string name { get; set; }
         [JsonConverter(typeof(StringEnumConverter))]
        public PromotionPriorityEnum priority { get; set; }
        public string promotionHref { get; set; }
        public string promotionId { get; set; }
        public string promotionImageUrl { get; set; }
         [JsonConverter(typeof(StringEnumConverter))]
        public PromotionStatusEnum promotionStatus { get; set; }
        public string startDate { get; set; }
    }
}
