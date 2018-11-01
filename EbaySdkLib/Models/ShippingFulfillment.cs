using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class ShippingFulfillment
    {
        public string fulfillmentId { get; set; }
        public LineItems[] lineItems { get; set; }
        public string shipmentTrackingNumber { get; set; }
        public string shippedDate { get; set; }
        public string shippingCarrierCode { get; set; }
    }
}
