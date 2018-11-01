using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
 public   class GetinventoryItemGroupResponse
    {
        public object aspects { get; set; }
        public string description { get; set; }
        public string inventoryItemGroupKey { get; set; }
        public string[] imageUrls { get; set; }
        public string subtitle { get; set; }
        public string title { get; set; }
        public string[] variantSKUs { get; set; }
        public VariesBy variesBy { get; set; }

    }
}
