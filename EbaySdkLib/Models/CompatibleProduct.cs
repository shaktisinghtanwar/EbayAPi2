using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
 public   class CompatibleProduct
        {

        public ProductFamilyProperties productFamilyProperties { get; set; }
        public ProductIdentifier productIdentifier { get; set; }
        public string notes { get; set; }
        }
    }
