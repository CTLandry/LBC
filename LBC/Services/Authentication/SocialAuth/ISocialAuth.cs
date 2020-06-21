using System;
using System.Threading.Tasks;
using LBC.Services.Authentication.Common;

namespace LBC.Services.Authentication.SocialAuth
{
    public interface ISocialAuth
    {
        public abstract Task<T> Authenticate<T>(AuthParameters authParameters);
        public abstract Task<T> RefreshAuthentication<T>(AuthParameters authParameters);
    }
}
