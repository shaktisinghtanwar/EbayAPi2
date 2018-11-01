using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Models
{
 public   class Contact
    {

        public string companyName { get; set; }
        public Address contactAddress { get; set; }
        public string fullName { get; set; }
        public PhoneNumber phoneNumber { get; set; }
    }
}
