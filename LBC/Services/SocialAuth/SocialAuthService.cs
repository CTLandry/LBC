using System;
using System.Threading.Tasks;
using LBC.Services.Base;

namespace LBC.Services.SocialAuth
{
    public class SocialAuthService : BaseService, ISocialAuth
    {
        public SocialAuthService()
        {
        }

        public async Task Authenticate(string scheme)
        {
            throw new NotImplementedException();
        }
    }
}
