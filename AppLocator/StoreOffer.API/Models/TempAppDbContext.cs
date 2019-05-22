using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreOffer.API.Models
{
    public class TempAppDbContext
    {
        public TempAppDbContext()
        {
            Stores = new List<Store>()
            {
                new Store()
                {
                    Name = "H&M",
                    FullOffer = "Köp 3 varor betala för 2. Billigaste varan gratis.",
                    Offer = "Köp 3 betala för 2",
                    LocationLatitude = 59.32944,
                    LocationLongitude = 18.06861,
                    LogoUrl = "HmLogo.png"
                },
                new Store()
                {
                    Name = "Red Bull",
                    FullOffer = "Köp 3 varor betala för 2. Billigaste varan gratis.",
                    Offer = "Köp 3 betala för 2",
                    LocationLatitude = 59.324806,
                    LocationLongitude = 18.063711,
                    LogoUrl = "RedbullLogo.png"
                },
                new Store()
                {
                    Name = "Disney",
                    FullOffer = "Köp 3 varor betala för 2. Billigaste varan gratis.",
                    Offer = "Köp 3 betala för 2",
                    LocationLatitude = 59.335179,
                    LocationLongitude = 18.062621,
                    LogoUrl = "DisneyLogo.png"
                },
                new Store()
                {
                    Name = "Heineken",
                    FullOffer = "Köp 3 varor betala för 2. Billigaste varan gratis.",
                    Offer = "Köp 3 betala för 2",
                    LocationLatitude = 59.313218,
                    LocationLongitude = 18.074229,
                    LogoUrl = "HeinekenLogo.png"
                }
            };
        }

        public List<Store> Stores { get; private set; }
    }
}
