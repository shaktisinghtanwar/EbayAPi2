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
    public class OrderRefund
    {
        public Amount  amount { get; set; }
        public string refundDate { get; set; }
        public string refundReferenceId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RefundStatusEnum refundStatus { get; set; }
    }
}
