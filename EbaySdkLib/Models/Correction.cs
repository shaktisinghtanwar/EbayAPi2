namespace EbaySdkLib.Models
{
    public class Correction
    {
        public AspectValues[] aspectValues { get; set; }
        public string correctionCode { get; set; }
        public ProductAttribute[] productAttribute { get; set; }
        public string reason { get; set; }
    }
}