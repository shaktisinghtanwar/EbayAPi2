using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
   public  class RuleCriteria
    {
        public InventoryItem[] excludeInventoryItems { get; set; }
        public string[] excludeListingIds { get; set; }
        public InventoryItem[] markupInventoryItems { get; set; }
        public string[] markupListingIds { get; set; }
        public SelectionRule[] selectionRules { get; set; }
    }
}
