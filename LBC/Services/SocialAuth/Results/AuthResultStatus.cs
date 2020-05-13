using System;
using LBC.Services.Base;

namespace LBC.Services.SocialAuth.Results
{
    public class AuthResultStatus : BaseResultStatus
    {
        public new enum Status
        {
            Success,
            Failed,
            Exception,
            TimedOut,
            NotFound
        }
    }
}
