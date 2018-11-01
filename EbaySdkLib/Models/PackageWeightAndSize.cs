using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
  public  class PackageWeightAndSize
        {
        public Dimensions dimensions { get; set; }
        public PackageTypeEnum packageType { get; set; }
        public Weight weight { get; set; }
        }
    }
