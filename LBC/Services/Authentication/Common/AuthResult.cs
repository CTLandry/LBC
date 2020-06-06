using System;
namespace LBC.Services.Authentication.Common
{
    public class AuthResult
    {
        public readonly AuthStatus authStatus;
        public readonly string resultMessage;

        public AuthResult(AuthStatus status)
        {
            authStatus = status;
        }

        public AuthResult(AuthStatus status, string message)
        {
            authStatus = status;
            resultMessage = message;
        }
    }
}
