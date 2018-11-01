using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbaySdkLib.Messages
    {
  public  class MetadataReturnPolicy
        {
        public string categoryId { get; set; }
        public string categoryTreeId { get; set; }
        public bool required { get; set; }
        }
    }
