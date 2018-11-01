using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
   public  class SelectedInventoryDiscount
    {
    public DiscountBenefit discountBenefit { get; set; }
    public string discountId { get; set; }
    public InventoryCriterion inventoryCriterion { get; set; }
    public string ruleOrder { get; set; }
   }
 }

