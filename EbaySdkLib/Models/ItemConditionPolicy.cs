using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
    public class ItemConditionPolicy
        {
        public string categoryId { get; set; }
        public string categoryTreeId { get; set; }
        public bool itemConditionRequired { get; set; }
        public ItemCondition[] itemConditions { get; set; }
        }

    }
