using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbaySdkLib.Messages
    {
  public  class MetadataGetreturnPolicyresponse
        {
        public ReturnPolicy[] returnPolicies { get; set; }
        public Warnings[] warnings { get; set; }
        }
    }
