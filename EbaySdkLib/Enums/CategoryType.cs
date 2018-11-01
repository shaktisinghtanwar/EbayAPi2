using Newtonsoft.Json;
namespace EbaySdkLib.Models
{
    public class CategoryType
        {
         [JsonProperty("default")]
        public bool @default { get; set; }
        public CategoryTypeEnum name { get; set; }
        }
    public enum CategoryTypeEnum
    {
        MOTORS_VEHICLES,
        ALL_EXCLUDING_MOTORS_VEHICLES
    }
}
