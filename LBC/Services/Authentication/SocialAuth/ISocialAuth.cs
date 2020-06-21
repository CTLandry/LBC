using System;
using System.Threading.Tasks;
using LBC.Services.Authentication.Common;

namespace LBC.Services.Authentication.SocialAuth
{
    public interface ISocialAuth
    {
        Task<IAuthenticatonResult> Authenticate(AuthParameters authParameters);
        Task<IAuthenticatonResult> RefreshAuthentication(AuthParameters authParameters);
    }
}
