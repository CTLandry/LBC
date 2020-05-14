using LBC.Services.Base;
using Xamarin.Essentials;

namespace LBC.Domain.SocialAuth.Results
{
    public class SocialAuthResult<TResult, TMessage> : BaseServiceResult<TResult, TMessage>
    {
        public readonly WebAuthenticatorResult WebAuthResult;

        public SocialAuthResult(TResult result, TMessage message) : base(result, message)
        {
          
        }

        public SocialAuthResult(TResult result, TMessage message, WebAuthenticatorResult webAuthResult) : base(result, message)
        {
            WebAuthResult = webAuthResult;
        }
    }
}
