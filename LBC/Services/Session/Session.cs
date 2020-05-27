using System;
using System.Threading.Tasks;

namespace LBC.Services.Session
{
    public class Session : ISession
    {
        public Task<bool> SessionIsValid()
        {
            return Task.Run(() => false);
        }
    }
}
