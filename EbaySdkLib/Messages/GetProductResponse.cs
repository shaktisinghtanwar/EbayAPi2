using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
    public class GetProductResponse
    {
        public AdditionalImage[] additionalImages { get; set; }
        public Aspect[] aspects { get; set; }
        public string brand { get; set; }
        public string description { get; set; }
        public string[] ean { get; set; }
        public string epid { get; set; }
        public string[] gtin { get; set; }
        public AdditionalImage[] image { get; set; }
        public string[] isbn { get; set; }
        public string[] mpn { get; set; }
        public string[] otherApplicableCategoryIds { get; set; }
        public string primaryCategoryId { get; set; }
        public string productWebUrl { get; set; }
        public string title { get; set; }
        public string[] upc { get; set; }
        public string version { get; set; }
    }
}
