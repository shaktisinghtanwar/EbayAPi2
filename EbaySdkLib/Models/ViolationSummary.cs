using EbaySdkLib.Enums;
using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class ViolationSummary
    {
        public ComplianceTypeEnum complianceType { get; set; }
        public MarketplaceIdEnum marketplaceId { get; set; }
        public int listingCount { get; set; }

    }
}