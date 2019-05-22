using Akavache;
using AppLocator.Interfaces.Repository;
using AppLocator.Models.Constants;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace AppLocator.Services.Data
{
    public class BaseService
    {
        protected readonly IGenericRepository repository;
        protected readonly IBlobCache cache;

        public BaseService(IGenericRepository repository, IBlobCache cache)
        {
            this.repository = repository;
            this.cache = cache ?? BlobCache.LocalMachine;
        }

        protected async Task<T> GetAsync<T>(string resourceEndpoint, string cacheKey)
        {
            var data = await GetFromCacheAsync<T>(cacheKey);
            if (data != null)
            {
                return data;
            }

            var uri = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = resourceEndpoint
            };

            data = await repository.GetAsync<T>(uri.ToString());
            await cache.InsertObject(CacheConstants.StoreCacheName, data, TimeSpan.FromSeconds(60));

            return data;
        }

        private async Task<T> GetFromCacheAsync<T>(string cacheKey)
        {
            try
            {
                return await cache.GetObject<T>(cacheKey);
            }
            catch (KeyNotFoundException)
            {
                return default(T);
            }
        }
    }
}