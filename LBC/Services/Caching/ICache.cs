using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LBC.Services.Caching
{
    public interface ICache
    {

        Task<T> CacheUrlData<T>(HttpClient client, string url, int days, bool forceRefresh);
        Task<T> CacheData<T>(CacheDataKey key, T data, int days);
        Task<T> GetData<T>(CacheDataKey key);
        Task EmptyCache();
        Task EmptyCache(CacheDataKey key);
        Task EmptyExpired();

    }
}
