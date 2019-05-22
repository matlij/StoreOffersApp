using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppLocator.Models;
using SQLite;

namespace AppLocator.Database
{
    public class StoreDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public StoreDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Settings>().Wait();
        }

        public async Task<Settings> GetSettingsAsync(int id)
        {
            var settings = await _database.Table<Settings>()
                .Where(s => s.ID == id)
                .FirstOrDefaultAsync();

            return settings ?? new Settings(){ StoreOfferRadius = 20.0, SearchOfferIntervalSeconds = 60 };
        }

        public Task<int> SaveSettingsAsync(Settings settings)
        {
            if (settings.ID != 0)
            {
                return _database.UpdateAsync(settings);
            }
            else
            {
                return _database.InsertAsync(settings);
            }
        }
    }
}
