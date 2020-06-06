using System;
using System.Threading.Tasks;
using LBC.Configuration.Configs;
using LBC.Infrastructure.Logging;
using LBC.Services.Authentication.Common;
using LBC.Services.User.Session;
using Xamarin.Essentials;

namespace LBC.Services.Authentication.SocialAuth
{
    public class SocialAuthenticationService : AuthenticationService
    {
        

        public SocialAuthenticationService(ILogger logger,
            ISession session, IConfiguration config) : base(logger, config, session)
        {
        }

        public async override Task<AuthResult> Authenticate(AuthParameters authParameters)
        {
            try
            {
                WebAuthenticatorResult r = null;

                var authUrl = new Uri(config.AuthApiSettings.socialAuthEndPoint + authParameters.AuthType.ToString());
                var callbackUrl = new Uri("lbcauth://");

                r = await WebAuthenticator.AuthenticateAsync(authUrl, callbackUrl);

                return new AuthResult(AuthStatus.Success);
            }
            catch (Exception ex)
            {
                await logger.LogToDebugger(ex.Message);
                return new AuthResult(AuthStatus.Error, ex.Message);
            }
        }

        public async override Task<AuthResult> RefreshAuthentication(AuthParameters authParameters)
        {
            return await Authenticate(authParameters);
        }

       
    }
}
