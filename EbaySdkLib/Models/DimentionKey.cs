using EbaySdkLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
    public class DimensionKey
    {
        public DataTypeEnum dataType { get; set; }
        public string key { get; set; }
        public string localizedName { get; set; }
    }
}
