using System.Collections.Generic;
using EbaySdkLib.Enums;
using EbaySdkLib.Models;
namespace EbaySdkLib.Messages
{
    public class GetCategoryTreeResponse
    {
        public List<MarketplaceIdEnum> applicableMarketplaceIds { get; set; }
        public string categoryTreeId { get; set; }
        public string categoryTreeVersion { get; set; }
        public CategoryTreeNode rootCategoryNode { get; set; }
    }
}
