using System;
using System.Threading.Tasks;

namespace LBC.Services.Authentication.Common
{
    public interface IAuthenticate
    {
        Task<AuthResult> Authenticate(AuthParameters authParameters);
        Task<AuthResult> RefreshAuthentication(AuthParameters authParameters);
    }
}
