using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EbaySdkLib.Models
{
    public class TimeDuration
    {
        public string value { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TimeDurationUnitEnum unit { get; set; }
    }
}
