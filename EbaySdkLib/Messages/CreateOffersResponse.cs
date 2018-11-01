using EbaySdkLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Messages
    {
    public class CreateOffersResponse
        {
        public Warnings[] warnings { get; set; }
        public string offerId { get; set; }

        public Errors[] Errors { get; set; }
        }
    }
