using System;
using LBC.Models.User;

namespace LBC.Services.Authentication.Common
{
    public class AuthResult : IAuthenticatonResult
    {
        public AuthStatus Status { get; }
        public string Message { get; }
        public string AccessToken { get; }
        public string RefreshToken { get; set; }
        public DateTimeOffset? TokenExpires { get; set; }
        public User_Model User { get; set; }

        public AuthResult(AuthStatus status)
        {
            Status = status;
        }

        public AuthResult(AuthStatus status, string message)
        {
            Status = status;
            Message = message;
        }

        public AuthResult(AuthStatus status, string message,
            string accessToken, string refreshToken, DateTimeOffset? expires, User_Model user)
        {
            Status = status;
            Message = message;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            TokenExpires = expires;
            User = user;
        }

      
    }
}
