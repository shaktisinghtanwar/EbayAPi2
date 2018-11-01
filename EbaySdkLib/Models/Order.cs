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
    public class Order
    {
        public Buyer buyer { get; set; }
        public string buyerCheckoutNotes { get; set; }
        public CancelStatus cancelStatus { get; set; }
        public string creationDate { get; set; }
        public List<string> fulfillmentHrefs { get; set; }
        public List<FulfillmentStartInstruction> fulfillmentStartInstructions { get; set; }
        public string lastModifiedDate { get; set; }
        public List<LineItem> lineItems { get; set; }
        public string orderFulfillmentStatus { get; set; }
        public string orderId { get; set; }
           [JsonConverter(typeof(StringEnumConverter))]
        public OrderFulfillmentStatusEnum orderPaymentStatus { get; set; }
        public PaymentSummary paymentSummary { get; set; }
        public PricingSummary pricingSummary { get; set; }
        public string sellerId { get; set; }
    }
}
