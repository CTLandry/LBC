using System;
namespace LBC.Services.SocialAuth.Results
{
    public static class AuthResult
    {
        public enum Status
        {
            Success = 1,
            Failed = 2,
            TimedOut = 3,
            Rejected = 4,
            Exception = 5
        }
    }
}
