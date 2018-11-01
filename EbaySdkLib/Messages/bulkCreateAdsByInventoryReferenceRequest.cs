using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
   public class bulkCreateAdsByInventoryReferenceRequest
    {
        public List<Ad> ads { get; set; }
        public string adId { get; set; }
        public List<Warnings> errors { get; set; }
        public string inventoryReferenceId { get; set; }
        public string inventoryReferenceType { get; set; }
        public string statusCode { get; set; }
        public string listingId { get; set; }
        public string bidPercentage { get; set; }
       

    }
}
