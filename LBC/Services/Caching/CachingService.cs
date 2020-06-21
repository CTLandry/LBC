using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using LBC.Configuration.Configs;
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace LBC.Services.Caching
{
    public class CachingService : ICache
    {
        public CachingService(IConfiguration config)
        {
            Barrel.ApplicationId = config.CacheSettings.barrelid;
        }

        /// <summary>
        /// Cache tokens
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key for token</param>
        /// <param name="days">expiration duration</param>
        /// <returns></returns>
        public async Task<T> CacheData<T>(CacheDataKey key, T data, int days)
        {
            try
            {
                return await Task.Run<T>(() =>
                {
                    var json = data == null ? String.Empty : JsonConvert.SerializeObject(data);

                    if (Barrel.Current.IsExpired(key.ToString()))
                    {
                        Barrel.Current.EmptyExpired();
                    }

                    Barrel.Current.Add(key.ToString(), json, TimeSpan.FromDays(days));

                    if (string.IsNullOrWhiteSpace(json))
                    {
                        return default(T);
                    }

                    var settings = new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    };

                    return JsonConvert.DeserializeObject<T>(json, settings);
                });

            }
            catch (SystemException ex)
            {
                Debug.WriteLine($"Cache Token Error: {ex}");
                throw (ex);
            }

        }

        /// <summary>
        /// Retrieves the cached token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Token's key</param>
        /// <returns></returns>
        public async Task<T> GetData<T>(CacheDataKey key)
        {
            try
            {
                return await Task.Run<T>(() =>
                {
                    var json = String.Empty;

                    //check cache if it is not expired and a refresh is not forced
                    if (!Barrel.Current.IsExpired(key.ToString()))
                    {
                        json = Barrel.Current.Get<string>(key.ToString());
                    }

                    if (string.IsNullOrWhiteSpace(json))
                    {
                        return default(T);
                    }

                    var settings = new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    };

                    return JsonConvert.DeserializeObject<T>(json, settings);
                });

            }
            catch (SystemException ex)
            {
                Debug.WriteLine($"Cache Token Error: {ex}");
                throw (ex);
            }
        }

        /// <summary>
        /// Get data from a url endpoint and cache the json return
        /// </summary>
        /// <typeparam name="T">Data Definition</typeparam>
        /// <param name="url">End Point</param>
        /// <param name="days">How Long To Cache the Data</param>
        /// <param name="forceRefresh">Whether or not to force refreshes</param>
        /// <returns></returns>
        public async Task<T> CacheUrlData<T>(HttpClient client, string url, int days, bool forceRefresh)
        {
            var json = string.Empty;

            try
            {
                //check cache if it is not expired and a refresh is not forced
                if (!Barrel.Current.IsExpired(url) && !forceRefresh)
                {
                    json = Barrel.Current.Get<string>(url);
                }

                if (Barrel.Current.IsExpired(url))
                {
                    Barrel.Current.EmptyExpired();
                }

                //if internet available grab server update of T
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    var responseMessage = await client.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        json = await responseMessage.Content.ReadAsStringAsync();
                        Barrel.Current.Add(url, json, TimeSpan.FromDays(days));

                    }
                }

                if (string.IsNullOrWhiteSpace(json))
                {
                    return default(T);
                }
                var settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };
                return JsonConvert.DeserializeObject<T>(json, settings);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Cache Error: {ex}");
                throw (ex);
            }
        }

        /// <summary>
        /// Clear the entire cache
        /// </summary>
        /// <returns></returns>
        public async Task EmptyCache()
        {
            try
            {
                await Task.Run(() => Barrel.Current.EmptyAll());
            }
            catch (SystemException ex)
            {
                Debug.WriteLine($"Cache Empty Error: {ex}");
                throw (ex);
            }
        }

        /// <summary>
        /// Clears the cache of a specific key
        /// </summary>
        /// <param name="key">The key the cache was stored with usually the url the data was pulled from</param>
        /// <returns></returns>
        public async Task EmptyCache(CacheDataKey key)
        {
            try
            {
                await Task.Run(() => Barrel.Current.Empty(key.ToString()));
            }
            catch (SystemException ex)
            {
                Debug.WriteLine($"Cache Empty {key} Error: {ex}");
                throw (ex);
            }
        }

        /// <summary>
        /// Empty all expired cache data
        /// </summary>
        /// <returns></returns>
        public async Task EmptyExpired()
        {
            try
            {
                await Task.Run(() => Barrel.Current.EmptyExpired());
            }
            catch (SystemException ex)
            {
                Debug.WriteLine($"Cache Empty Expired Error: {ex}");
                throw (ex);
            }
        }
    }
}
