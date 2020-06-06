using System;
namespace LBC.Services.Authentication.Common
{
    public class AuthParameters
    {
        public readonly AuthType AuthType;
       
        public AuthParameters(AuthType type)
        {
            AuthType = type; 
        }
    }
}
