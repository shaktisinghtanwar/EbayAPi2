using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
    public class GetShippingFulfillmentResponse
    {
        public string fulfillmentId { get; set; }
        public List<LineItem> lineItems { get; set; }
        public string shipmentTrackingNumber { get; set; }
        public string shippedDate { get; set; }
        public string shippingCarrierCode { get; set; }
    }
}
