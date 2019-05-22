using AppLocator.Interfaces.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppLocator.Utility
{
    public class GeoLocator : IGeoLocator
    {
        public async Task<Location> GetLocationAsync()
        {
            Location location = null;
            try
            {
                location = await Geolocation.GetLastKnownLocationAsync();
                //location = new Location(59.348289, 18.382280);
            }
            catch (Exception e)
            {
                Debug.Write("Get location failed: " + e.Message);
            }

            return location;
        }
    }
}
