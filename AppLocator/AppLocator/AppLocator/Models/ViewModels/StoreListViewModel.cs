using AppLocator.Extensions;
using AppLocator.Interfaces.Services.Data;
using AppLocator.Interfaces.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppLocator.Models.ViewModels
{
    public class StoreListViewModel
    {
        private readonly IStoreService _storeService;

        public StoreListViewModel(IStoreService storeService)
        {
            _storeService = storeService;
            GetStores();
        }

        public IList<Store> Stores { get; set; }

        private async void GetStores()
        {
            Stores = await _storeService.GetAllStoresAsync();
        }
    }
}
