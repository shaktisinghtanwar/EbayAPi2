using EbaySdkLib.Enums;

namespace EbaySdkLib.Models
{
    public class ProcessResolutionViolation
    {
        public AspectValues aspectValues { get; set; }
        public string correctionCode { get; set; }
        public ProductAttributeEnum productAttribute { get; set; }
        public string reason { get; set; }
    }
}