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
  public   class CampaignCriterion
    {

        public bool  autoSelectFutureInventory { get; set; }
      
       [JsonConverter(typeof(StringEnumConverter))]
        public CriterionTypeEnum criterionType { get; set; }
        public SelectionRule[] selectionRules { get; set; }
    }
}
