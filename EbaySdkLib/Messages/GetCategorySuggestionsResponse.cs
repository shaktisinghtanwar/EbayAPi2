using EbaySdkLib.Models;
using System.Collections.Generic;

namespace EbaySdkLib.Messages
{
    public class GetCategorySuggestionsResponse
    {
        public List<CategorySuggestion> categorySuggestions { get; set; }
        public string categoryTreeId { get; set; }
        public string categoryTreeVersion { get; set; }
    }

}
