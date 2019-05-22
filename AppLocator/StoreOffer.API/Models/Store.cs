using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreOffer.API.Models
{
    public class Store
    {
        public string Name { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
        public string Offer { get; set; }
        public string FullOffer { get; set; }
        public string LogoUrl { get; set; }
    }
}
