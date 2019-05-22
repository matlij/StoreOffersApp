using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppLocator.Interfaces.Repository;
using AppLocator.Models.Constants;
using Newtonsoft.Json;
using Polly;

namespace AppLocator.Repository
{
    public class GenericRepository : IGenericRepository
    {
        public async Task<T> GetAsync<T>(string uri)
        {
            try
            {
                using (var client = CreateHttpClient())
                {
                    //var response = await Policy
                    //    .Handle<WebException>(ex =>
                    //    {
                    //        Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                    //        return true;
                    //    })
                    //    .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                    //    .ExecuteAsync(async () => await client.GetAsync(uri));

                    var response = await client.GetAsync(ApiConstants.StoreEndpoint);

                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var json = JsonConvert.DeserializeObject<T>(jsonResult);
                    return json;
                }
            }
            catch (Exception e)
            {
                Debug.Write($"HttpClient failed. {e.Message}");
                throw;
            }
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiConstants.BaseApiUrl)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
