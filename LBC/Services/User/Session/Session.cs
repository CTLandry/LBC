using System;
using System.Threading.Tasks;
using LBC.Models.User;

namespace LBC.Services.User.Session
{
    public class Session : ISession
    {
      
        public DateTimeOffset? TokenExpires { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public User_Model User { get; set; }

        public async Task<bool> SessionIsValid()
        {
            return false;
        }
    }
}
