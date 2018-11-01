using EbaySdkLib.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
{
   public class GetPaymentpolicyRequest
    {
       public string payment_policy_id { get; set; }
    }
}
