using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
    {
 public   class GetItemConditionPoliciesResponse
        {
        public ItemConditionPolicy[] itemConditionPolicies { get; set; }
        public Warnings[] warnings { get; set; }
        }
    }
