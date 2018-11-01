using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
    {
    public class Location
        {
        public Address address { get; set; }
        public GeoCoordinates geoCoordinates { get; set; }
        public string locationId { get; set; }
        }
    }
