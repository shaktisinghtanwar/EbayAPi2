using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace EbaySdkLib.Models
{
   public  class Program
    {
       
     [JsonConverter(typeof(StringEnumConverter))]
        public  ProgramTypeEnum  programType { get; set; }
    }
}
