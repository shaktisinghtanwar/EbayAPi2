

namespace EbaySdkLib.Models
{
    public class MigrateListingRespons
    {
        public int statusCode { get; set; }
        public string listingId { get; set; }
        public string inventoryItemGroupKey { get; set; }
        public MarketplaceIdEnum marketplaceId { get; set; }
        public InventoryItem[] inventoryItems { get; set; }
        public Warnings[] errors { get; set; }
        public Warnings[] warnings { get; set; }

    }
}