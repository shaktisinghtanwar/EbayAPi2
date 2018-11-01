using EbaySdkLib.Models;
using System.Collections.Generic;

namespace EbaySdkLib.Messages
{
    public class GetCategorySubtreeResponse
    {
        public CategoryTreeNode categorySubtreeNode { get; set; }
        public string categoryTreeId { get; set; }
        public string categoryTreeVersion { get; set; }
    }
    public class CategoryTreeNode
    {
        public Category category { get; set; }
        public int categoryTreeNodeLevel { get; set; }
        public List<CategoryTreeNode> childCategoryTreeNodes { get; set; }
        public string leafCategoryTreeNode { get; set; }
        public string parentCategoryTreeNodeHref { get; set; }
    }
}
