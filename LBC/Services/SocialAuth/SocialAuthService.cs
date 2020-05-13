﻿using System;
using System.Threading.Tasks;
using LBC.Services.Base;
using Xamarin.Essentials;
using LBC.Services.SocialAuth.Exceptions;
using LBC.Services.SocialAuth.Results;

namespace LBC.Services.SocialAuth
{
    public class SocialAuthService : BaseService, ISocialAuth
    {
        //TODO refactor into config
        //Then refactor that into azure keyvault
        const string authenticationUrl = "https://localhost:5003/mobileauth/";

        public SocialAuthService()
        {
        }

        public async Task<SocialAuthResult<BaseResultStatus>> Authenticate(string scheme)
        {
            try
            {
                var authUrl = new Uri(authenticationUrl + scheme);
                var callbackUrl = new Uri("xamarinessentials://");

                WebAuthenticatorResult webAuthResult = null;

                webAuthResult = await WebAuthenticator.AuthenticateAsync(authUrl, callbackUrl);

                var token = webAuthResult?.AccessToken ?? webAuthResult?.IdToken;

                return new SocialAuthResult<BaseResultStatus>(BaseResultStatus.Success, webAuthResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Auth the foook!");
            }
        }

        public override void Dispose()
        {
            
        }

     
    }
}
