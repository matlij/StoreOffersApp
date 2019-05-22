using Akavache;
using AppLocator.Interfaces.Repository;
using AppLocator.Interfaces.Services;
using AppLocator.Interfaces.Services.Data;
using AppLocator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppLocator.Services.Data
{
    public class SettingsService : ISettingsService
    {
        //public SettingsService(IGenericRepository repository, IBlobCache cache) :base(repository, cache)
        //{

        //}

        public async Task<Settings> GetSettings()
        {
            return await App.DataBase.GetSettingsAsync(1);
        }
    }
}
