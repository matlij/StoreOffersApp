using System;
using System.Collections.Generic;
using System.Text;

namespace AppLocator.Models.ViewModels
{
    public class StoreView
    {
        public string Name { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
        public string Offer { get; set; }
        public string FullOffer { get; set; }
        public double DistanceToCustomer { get; set; }
        public string LogoUrl { get; set; }
    }
}
