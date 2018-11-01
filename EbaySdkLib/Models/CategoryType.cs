using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EbaySdkLib.Models
{
    public class CategoryType
        {
         [JsonProperty("default")]
        public bool @default { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CategoryTypeEnum name { get; set; }
        }
}
