using System;
using LBC.Services.Authentication.Common;
using Xamarin.Essentials;

namespace LBC.Services.Authentication.SocialAuth
{
    public class SocialAuthResult : AuthResult
    {
        public WebAuthenticatorResult SocialAuthData {get;}

        public SocialAuthResult(AuthStatus status, string message, WebAuthenticatorResult socialAuthData)
            : base(status, message)
        {
            SocialAuthData = socialAuthData;
        }
    }
}
