namespace EbaySdkLib.Models
{
    public class ConflictingProduct
    {
        public string conflictCode { get; set; }
        public DifferentiatingAspect[] differentiatingAspects { get; set; }
        public string epid { get; set; }
        public string reason { get; set; }

    }
}