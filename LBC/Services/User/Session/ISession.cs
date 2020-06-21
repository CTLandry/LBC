using System;
using System.Threading.Tasks;
using LBC.Models.User;
using LBC.Services.Caching;

namespace LBC.Services.User.Session
{
    public interface ISession
    {
        Task<bool> SessionIsValid();
        DateTimeOffset? TokenExpires { get; set; }
        string AccessToken { get; set; }
        string RefreshToken { get; set; }
        User_Model User { get; set; }
        Task LoadSession(ICache cache);
        Task ClearSession(ICache cache);
    }
}
