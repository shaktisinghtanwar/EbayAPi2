using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EbaySdkLib.Models
{
    public class Region
    {
        public string regionName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RegionTypeEnum regionType { get; set; }
    }
}
