using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
   public class ProductAdoptionPolicy
        {
        public string categoryId { get; set; }
        public string categoryTreeId { get; set; }
        public Exclusion exclusion { get; set; }
        public bool productRequired { get; set; }
        }
    }
