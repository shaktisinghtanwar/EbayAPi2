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
   public  class Payment
    {
        public Amount amount { get; set; }
        public string paymentDate { get; set; }
        public List<PaymentHold> paymentHolds { get; set; }
          [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethodTypeEnum   paymentMethod { get; set; }
        public string paymentReferenceId { get; set; }
        public PaymentStatusEnum paymentStatus { get; set; }
    }
}
