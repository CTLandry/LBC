using System;
using System.Threading.Tasks;
using LBC.Configuration.Configs;
using LBC.Infrastructure.Logging;
using LBC.Services.Authentication.Common;
using LBC.Services.User.Session;
using Xamarin.Essentials;

namespace LBC.Services.Authentication.SocialAuth
{
    public class SocialAuthenticationService : AuthenticationService, ISocialAuth
    {
        

        public SocialAuthenticationService(ILogger logger,
            ISession session, IConfiguration config) : base(logger, config, session)
        {
        }

        public override async Task<IAuthenticatonResult> Authenticate(AuthParameters authParameters)
        {
            try
            {
                WebAuthenticatorResult authApiResultData = null;

                var authUrl = new Uri(config.AuthApiSettings.socialAuthEndPoint + authParameters.AuthType.ToString());
                var callbackUrl = new Uri("xamarinessentials://");

                authApiResultData = await WebAuthenticator.AuthenticateAsync(authUrl, callbackUrl);
                var user = new Models.User.User_Model();
                user.Name = authApiResultData.Properties["name"] ?? "Unknown";

                return new AuthResult(AuthStatus.Success, "", authApiResultData.AccessToken, authApiResultData.RefreshToken, authApiResultData.ExpiresIn, user);
            }
            catch (Exception ex)
            {
                await logger.LogToDebugger(ex.Message);
                return new AuthResult(AuthStatus.Error, ex.Message);
            }
        }

        public override async Task<IAuthenticatonResult> RefreshAuthentication(AuthParameters authParameters)
        {
            throw new NotImplementedException();
        }

       
    }
}
