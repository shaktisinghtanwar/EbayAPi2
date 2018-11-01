using EbaySdkLib.Enums;

namespace EbaySdkLib.Models
{
    public class ListingViolation
    {
        public ComplianceTypeEnum complianceType { get; set; }
        public string listingId { get; set; }
        public string sku { get; set; }
        public string offerId { get; set; }
        public Violation[] violations { get; set; }
    }
}