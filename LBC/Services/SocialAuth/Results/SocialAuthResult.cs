using System;
using LBC.Services.Base;
using Xamarin.Essentials;

namespace LBC.Services.SocialAuth.Results
{
    public class SocialAuthResult : BaseResult
    {
        public readonly WebAuthenticatorResult AuthResult;

        public SocialAuthResult(BaseResultStatus.Status status,
            WebAuthenticatorResult authResult) : base(status)
        {
            this.AuthResult = authResult;
        }

       
    }
}
