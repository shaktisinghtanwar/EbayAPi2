using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class Ad
    {
        public string adId { get; set; }
        public string href { get; set; }
        public string bidPercentage { get; set; }
        public string inventoryReferenceId { get; set; }
        public string inventoryReferenceType { get; set; }
        public string listingId { get; set; }
    }
}
