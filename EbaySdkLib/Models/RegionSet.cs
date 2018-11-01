using System.Collections.Generic;

namespace EbaySdkLib.Models
{
    public class RegionSet
    {
        public List<Region> regionExcluded { get; set; }
        public List<Region> regionIncluded { get; set; }
    }
}
