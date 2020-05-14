using System;
namespace LBC.Domain.SocialAuth.Results
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
