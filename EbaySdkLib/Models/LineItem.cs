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
   public  class LineItem
    {
        public List<AppliedPromotion> appliedPromotions { get; set; }
        public DeliveryCost deliveryCost { get; set; }
        public Amount  discountedLineItemCost { get; set; }
        public GiftDetails giftDetails { get; set; }
        public string legacyItemId { get; set; }
        public string legacyVariationId { get; set; }
        public Amount lineItemCost { get; set; }
        public LineItemFulfillmentInstructions lineItemFulfillmentInstructions { get; set; }
          [JsonConverter(typeof(StringEnumConverter))]
        public LineItemFulfillmentStatusEnum lineItemFulfillmentStatus { get; set; }
        public string lineItemId { get; set; }
          [JsonConverter(typeof(StringEnumConverter))]
        public MarketplaceIdEnum listingMarketplaceId { get; set; }
        public LineItemProperties properties { get; set; }
        public MarketplaceIdEnum purchaseMarketplaceId { get; set; }
        public int  quantity { get; set; }
        public List<LineItemRefund> refunds { get; set; }
        public string sku { get; set; }
          [JsonConverter(typeof(StringEnumConverter))]
        public SoldFormatEnum soldFormat { get; set; }
        public List<Tax> taxes { get; set; }
        public string title { get; set; }
        public Amount total { get; set; }
    }
}
