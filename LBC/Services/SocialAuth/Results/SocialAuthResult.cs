using System;
using LBC.Services.Base;
using Xamarin.Essentials;

namespace LBC.Services.SocialAuth.Results
{
    public class SocialAuthResult<BaseResultStatus> : BaseResult<BaseResultStatus>
    {
        public readonly WebAuthenticatorResult AuthResult;

        public SocialAuthResult(BaseResultStatus status,
            WebAuthenticatorResult authResult) : base(status)
        {
            this.AuthResult = authResult;
        }
    }
}
