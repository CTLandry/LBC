using System;
using LBC.Services.Base;

namespace LBC.Services.SocialAuth.Exceptions
{
    public class SocialAuthException<T> : BaseServiceException<T>
    {
        public SocialAuthException()
        {
        }
    }
}
