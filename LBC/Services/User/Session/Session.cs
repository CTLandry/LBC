using System;
using System.Threading.Tasks;
using LBC.Models.User;
using LBC.Services.Caching;

namespace LBC.Services.User.Session
{
    public class Session : ISession
    {
        public DateTimeOffset? TokenExpires { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public User_Model User { get; set; }
      
        public async Task LoadSession(ICache cache)
        {
            var cachedSession = await cache.GetData<Session>(CacheDataKey.Session);
            if(cachedSession != null)
            {
                TokenExpires = cachedSession.TokenExpires;
                AccessToken = cachedSession.AccessToken;
                RefreshToken = cachedSession.RefreshToken;
                User = cachedSession.User;

            }
        }

        public async Task ClearSession(ICache cache)
        {
            TokenExpires = null;
            AccessToken = null;
            RefreshToken = null;
            User = null;

            await cache.EmptyCache(CacheDataKey.Session);
        }

        public async Task<bool> SessionIsValid()
        {
            return DateTimeOffset.Now < TokenExpires;
        }

       
    }
}
