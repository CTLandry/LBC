using System;
using System.Threading.Tasks;

namespace LBC.Services.User.Session
{
    public class Session : ISession
    {
        public Session()
        {
        }

        public async Task<bool> SessionIsValid()
        {
            return false;
        }
    }
}
