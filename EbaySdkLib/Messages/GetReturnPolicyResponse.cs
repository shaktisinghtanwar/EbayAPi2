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
    public class GetReturnPolicyResponse
        {
        public CategoryType[] categoryTypes { get; set; }
        public string description { get; set; }
        public bool extendedHolidayReturnsOffered { get; set; }
        public InternationalOverride internationalOverride { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MarketplaceIdEnum marketplaceId { get; set; }
        public string name { get; set; }
        public RefundMethodEnum refundMethod { get; set; }
        public string restockingFeePercentage { get; set; }
        public string returnInstructions { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ReturnMethodEnum returnMethod { get; set; }
        public TimeDuration returnPeriod { get; set; }
        public string returnPolicyId { get; set; }
        public bool returnsAccepted { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ReturnShippingCostPayerEnum returnShippingCostPayer { get; set; }
        }
    }
