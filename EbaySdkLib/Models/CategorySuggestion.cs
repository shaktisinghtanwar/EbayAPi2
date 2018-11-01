using System.Collections.Generic;

namespace EbaySdkLib.Models
{
    public class CategorySuggestion
    {
        public Category category { get; set; }
        public List<AncestorReference> categoryTreeNodeAncestors { get; set; }
        public int categoryTreeNodeLevel { get; set; }
        public string relevancy { get; set; }
    }
}
