using System;
using LBC.Infrastructure.Result;
using LBC.Services.Base;
using Xamarin.Essentials;

namespace LBC.Services.SocialAuth.Results
{
    public class SocialAuthResult<TResult, TMessage> : BaseServiceResult<TResult, TMessage>
    {
        public readonly WebAuthenticatorResult AuthResult;

        public SocialAuthResult(TResult result, TMessage message) : base(result, message)
        {
          
        }

        public SocialAuthResult(TResult result, TMessage message, WebAuthenticatorResult webAuthResult) : base(result, message)
        {
            AuthResult = webAuthResult;
        }
    }
}
