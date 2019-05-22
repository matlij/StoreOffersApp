using AppLocator.Models;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace AppLocator.Helpers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StorePage : ContentPage
	{
        private readonly Store store;

        public StorePage (Store store)
		{
			InitializeComponent ();

            this.store = store;
            BindingContext = store;
        }

        private async void ImageButtonMapClicked(object sender, EventArgs e)
        {
            var options = new MapLaunchOptions { Name = store.Name };
            await Map.OpenAsync(store.LocationLatitude, store.LocationLongitude, options);
        }
    }
}