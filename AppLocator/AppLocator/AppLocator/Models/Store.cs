using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace AppLocator.Models
{
    public class Store
    {
        public string Name { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
        public string Offer { get; set; }
        public string FullOffer { get; set; }
        public string LogoUrl { get; set; }
        public double DistanceToCustomer { get; set; }
    }
}
