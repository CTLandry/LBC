using System;
using System.Threading.Tasks;
using LBC.Domain.SocialAuth.Results;

namespace LBC.Services.SocialAuth
{
    public class SocialAuthMock : ISocialAuth
    {
        public SocialAuthMock()
        {
        }

        public Task<SocialAuthResult<TResult, TMessage>> Authenticate<TResult, TMessage>(string scheme)
        {
            throw new NotImplementedException();
        }
    }
}
