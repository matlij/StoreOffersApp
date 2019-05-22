using AppLocator.Interfaces.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace AppLocator.Models.ViewModels
{
    public class SettingsView
    {
        public SettingsView(IGeoLocator geoLocator)
        {
            SetPropertiesAsync(geoLocator);
        }

        private async void SetPropertiesAsync(IGeoLocator geoLocator)
        {
            UserLocation = await geoLocator.GetLocationAsync();
            Settings = await App.DataBase.GetSettingsAsync(1);
        }

        public Settings Settings { get; set; }
        public Location UserLocation { get; set; }
    }
}
