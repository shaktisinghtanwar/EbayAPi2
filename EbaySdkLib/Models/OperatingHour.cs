using EbaySdkLib.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
    public class OperatingHour
        {
         [JsonConverter(typeof(StringEnumConverter))]
        public DayOfWeekEnum dayOfWeekEnum { get; set; }
        public Interval[] intervals { get; set; }
        }
    }
