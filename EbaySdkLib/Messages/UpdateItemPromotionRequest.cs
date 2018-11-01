using EbaySdkLib.Enums;
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
  public   class UpdateItemPromotionRequest
    {
        public string description { get; set; }
        public DiscountRule[] discountRules { get; set; }
        public string endDate { get; set; }
        public InventoryCriterion inventoryCriterion { get; set; }
        public string marketplaceId { get; set; }
        public string name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PromotionPriorityEnum priority { get; set; }
        public string promotionImageUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PromotionStatusEnum promotionStatus { get; set; }
        public string startDate { get; set; }
    }
}
