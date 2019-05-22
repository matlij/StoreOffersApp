using AppLocator.Interfaces.Services.Data;
using AppLocator.Services.Data;
using AppLocator.Bootstrap;
using AppLocator.Interfaces.Utilities;
using AppLocator.Models.ViewModels;
using AppLocator.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System;
using Xamarin.Forms;

namespace AppLocator.Utility
{
    public class TaskLocator
    {
        //private readonly IStoreService storeService;

        //public TaskLocator()
        //{
        //}

        public async Task RunFindOfferLocator(CancellationToken token)
        {
            var settings = await App.DataBase.GetSettingsAsync(1);
            var storeService = AppContainer.Resolve<IStoreService>();
            var geoLocator = AppContainer.Resolve<IGeoLocator>();
            var offersSent = new List<Store>();

            await Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        var userLocation = await geoLocator.GetLocationAsync();
                        if (userLocation == null)
                        {
                            await Task.Delay(settings.SearchOfferIntervalSeconds * 1000, token);
                            continue;
                        }

                        var stores = await storeService.GetStoreOffersAsync();
                        var newStoreOffers = stores.Where(s => offersSent.FirstOrDefault(o => o.Name == s.Name) != null);

                        foreach (var store in newStoreOffers)
                        {
                            Device.BeginInvokeOnMainThread(() => MessagingCenter.Send(store, "StoreOfferFound"));
                            offersSent.Add(store);
                        }

                        //for (int j = stores.Count - 1; j > 0; j--)
                        //{
                        //    var store = stores[j];
                        //    var distanceToStore = Location.CalculateDistance(userLocation, store.Location, DistanceUnits.Kilometers);
                        //    if (distanceToStore < settings.StoreOfferRadius)
                        //    {
                        //        Device.BeginInvokeOnMainThread(() => MessagingCenter.Send(store, "StoreOfferFound"));
                        //        stores.RemoveAt(j);
                        //    }
                        //}
                    }
                    catch (Exception ex)
                    {
                        Debug.Write("FindOfferLocator failed. " + ex.Message);
                    }

                    await Task.Delay(settings.SearchOfferIntervalSeconds * 1000, token);
                }
            }, token);
        }
    }
}
