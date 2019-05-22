using System.Collections.Generic;
using System.Threading.Tasks;
using AppLocator.Models;
using Xamarin.Essentials;

namespace AppLocator.Interfaces.Services.Data
{
    public interface IStoreService
    {
        Task<List<Store>> GetAllStoresAsync();
        Task<List<Store>> GetStoreOffersAsync();
    }
}