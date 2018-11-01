using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
    {
   public class GetProductAdoptionPolicies
        {
        public ProductAdoptionPolicy[] productAdoptionPolicies { get; set; }
        public Warnings warnings { get; set; }
        }
    }
