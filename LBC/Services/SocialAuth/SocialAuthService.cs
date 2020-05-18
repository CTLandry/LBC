using System;
using System.Threading.Tasks;
using LBC.Domain.SocialAuth.Results;

namespace LBC.Services.SocialAuth
{
    public class SocialAuthService : ISocialAuth
    {
        //TODO refactor into config
        //Then refactor that into azure keyvault
        const string authenticationUrl = "https://localhost:5003/mobileauth/";

        public SocialAuthService()
        {
        }

        public async Task<SocialAuthResult<AuthResult.Status, string>> Authenticate<TResult, TMessage>(string scheme)
        {
            
        }
    }
}
