using System;
using System.Threading.Tasks;

namespace LBC.Services.User.Session
{
    public interface ISession
    {
        Task<bool> SessionIsValid();
    }
}
