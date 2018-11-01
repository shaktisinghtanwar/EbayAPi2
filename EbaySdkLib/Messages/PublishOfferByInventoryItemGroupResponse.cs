using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
    {
 public   class PublishOfferByInventoryItemGroupResponse
        {
        public Warnings[] warnings { get; set; }
        public string listingId { get; set; }
        }
    }
