using System.Threading.Tasks;
using LBC.Configuration.Configs;
using LBC.Infrastructure.Logging;
using LBC.Services._Base;
using LBC.Services.User.Session;

namespace LBC.Services.Authentication.Common
{
    public abstract class AuthenticationService : BaseService, IAuthenticate
    {
        public AuthenticationService(ILogger logger,
            IConfiguration config, ISession session) : base(logger, config, session)
        {
        }

        public abstract Task<AuthResult> Authenticate(AuthParameters authParameters);
        public abstract Task<AuthResult> RefreshAuthentication(AuthParameters authParameters);
       
    }
}
