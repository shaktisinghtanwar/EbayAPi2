namespace EbaySdkLib.Messages
{
    public class ProductSummary
    {
        public AdditionalImage[] additionalImages { get; set; }
        public Aspect[] aspects { get; set; }
        public string brand { get; set; }
        public string[] ean { get; set; }
        public string epid { get; set; }
        public string[] gtin { get; set; }
        public AdditionalImage[] image { get; set; }
        public string[] isbn { get; set; }
        public string[] mpn { get; set; }
        public string productHref { get; set; }
        public string productWebUrl { get; set; }
        public string title { get; set; }
        public string[] upc { get; set; }
    }
}