using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class InventoryReference
    {
        public string inventoryReferenceId { get; set; }
        public InventoryReferenceTypeEnum inventoryReferenceType { get; set; }
    }
}
