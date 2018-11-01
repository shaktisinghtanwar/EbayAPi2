using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
    public class FeeSummary
        {
        public Warnings[] warnings { get; set; }
        public MarketplaceIdEnum marketplaceId { get; set; }
        public Fee[] fees { get; set; }
        }
    }
