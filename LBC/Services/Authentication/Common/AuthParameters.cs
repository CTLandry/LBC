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

        public AuthParameters(string type)
        {
            switch(type)
            {
                case "Google":
                    {
                        AuthType = AuthType.Google;
                        break;
                    }
                case "Facebook":
                    {
                        AuthType = AuthType.Facebook;
                        break;
                    }
                default:
                    {
                        throw new SystemException("Auth type unknown");
                    }
            }
        }
    }
}
