using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
   public class AutomotivePartsCompatibilityPolicy
        {
        public string categoryId { get; set; }
        public string categoryTreeId { get; set; }
        public CompatibilityTypeEnum compatibilityBasedOn { get; set; }
        public CompatibleVehicleTypeEnum compatibleVehicleTypes { get; set; }
        public int maxNumberOfCompatibleVehicles { get; set; }
        }
    }
