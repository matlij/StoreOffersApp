using Akavache;
using AppLocator.Interfaces.Repository;
using AppLocator.Models;
using AppLocator.Models.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Xamarin.Essentials;
using AppLocator.Interfaces.Services.Data;
using AppLocator.Interfaces.Utilities;

namespace AppLocator.Services.Data
{
    public class StoreService : BaseService, IStoreService
    {
        private Dictionary<string, Store> _storeOfferFound;
        private readonly IGeoLocator _geoLocator;
        private readonly ISettingsService _settingsService;

        public StoreService(IGenericRepository repository, IGeoLocator geoLocator, 
            ISettingsService settingsService, IBlobCache cache = null) : base(repository, cache)
        {
            _storeOfferFound = new Dictionary<string, Store>();
            _geoLocator = geoLocator;
            this._settingsService = settingsService;
        }

        //public async Task<List<Store>> FindAllOffers(double storeOfferRadius)
        //{
        //    var stores = await GetStoresAsync(storeOfferRadius);

        //    foreach (var store in stores)
        //    {
        //        if(!_storeOfferFound.TryGetValue(store.Name, out var _))
        //        {
        //            _storeOfferFound.Add(store.Name, store);
        //        }
        //    }

        //    return stores;
        //}

        //public async Task<List<Store>> FindNewOffers(double storeOfferRadius)
        //{
        //    var stores = await GetStoresAsync(storeOfferRadius);

        //    var newStoreOffers = stores
        //        .Where(s => !_storeOfferFound.TryGetValue(s.Name, out var _))
        //        .ToList();

        //    newStoreOffers.ForEach(s => _storeOfferFound.Add(s.Name, s));

        //    return newStoreOffers;
        //}

        public async Task<List<Store>> GetAllStoresAsync()
        {
            var customerLocation = await _geoLocator.GetLocationAsync();
            if (customerLocation == null)
            {
                return null;
            }

            var stores = await GetAsync<List<Store>>(ApiConstants.StoreEndpoint, CacheConstants.StoreCacheName);

            stores.ForEach(
                s => s.DistanceToCustomer = Math.Round(
                        Location.CalculateDistance(customerLocation, s.LocationLatitude, s.LocationLongitude, DistanceUnits.Kilometers), 2));

            return stores;
        }

        public async Task<List<Store>> GetStoreOffersAsync()
        {
            var customerLocation = await _geoLocator.GetLocationAsync();
            if (customerLocation == null)
            {
                return null;
            }

            var stores = await GetAsync<List<Store>>(ApiConstants.StoreEndpoint, CacheConstants.StoreCacheName);

            stores.ForEach(
                s => s.DistanceToCustomer = Math.Round(
                        Location.CalculateDistance(customerLocation, s.LocationLatitude, s.LocationLongitude, DistanceUnits.Kilometers), 2));

            var settings = await _settingsService.GetSettings();

            return stores.Where(s => s.DistanceToCustomer < settings.StoreOfferRadius).ToList();
        }
    }
}
