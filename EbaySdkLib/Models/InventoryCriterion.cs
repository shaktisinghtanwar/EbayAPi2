using EbaySdkLib.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
   public  class InventoryCriterion
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public InventoryCriterionEnum inventoryCriterionType { get; set; }
        public InventoryItem[] inventoryItems { get; set; }
        public string[] listingIds { get; set; }
        public RuleCriteria ruleCriteria { get; set; }
    }
}
