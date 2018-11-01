using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
   public class ProcessResolution
    {
        public ConflictingProduct[] conflictingProducts { get; set; }
        public Correction[] corrections { get; set; }
        public string epid { get; set; }
        public string productHref { get; set; }
        public ProcessResolutionViolation[] violations { get; set; }
    }
}
