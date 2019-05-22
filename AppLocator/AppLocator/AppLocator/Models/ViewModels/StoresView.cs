using Akavache;
using AppLocator.Interfaces.Services.Data;
using AppLocator.Interfaces.Utilities;
using AppLocator.Repository;
using AppLocator.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace AppLocator.Models.ViewModels
{
    public class StoresView
    {
        private readonly IStoreService _storeService;

        public StoresView(IStoreService storeService)
        {
            _storeService = storeService;
            GetStores();
        }

        public IList<Store> Stores { get; set; }

        private async void GetStores()
        {
            Stores = await _storeService.GetStoreOffersAsync();
        }
    }
}
