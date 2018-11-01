namespace EbaySdkLib.Messages
{
    public class SuggestedProduct
    {
        public string[] additionalImageUrls { get; set; }
        public Aspect[] aspects { get; set; }
        public string brand { get; set; }
        public string description { get; set; }
        public string[] ean { get; set; }
        public string epid { get; set; }
        public string imageUrl { get; set; }
        public string[] isbn { get; set; }
        public string[] mpn { get; set; }
        public string[] otherApplicableCategoryIds { get; set; }
        public string primaryCategoryId { get; set; }
        public string title { get; set; }
        public string[] upc { get; set; }
        public string version { get; set; }

    }
}