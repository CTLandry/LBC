using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LBC.Services.Caching
{
    public interface ICache
    {

        Task<T> CacheUrlData<T>(HttpClient client, string url, int days, bool forceRefresh);
        Task<T> CacheToken<T>(string key, T data, int days);
        Task<T> GetToken<T>(string key);
        Task EmptyCache();
        Task EmptyCache(string key);
        Task EmptyExpired();

    }
}
