using System;
using System.Threading.Tasks;

namespace LBC.Services.Session
{
    public class Session : ISession
    {
       
        public string AuthToken { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiresTime { get; set; }



        public Task<bool> SessionIsValid()
        {
            return Task.Run(() => false);
        }
    }
}
