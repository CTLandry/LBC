using System;
using LBC.Services.Base;

namespace LBC.Domain.SocialAuth.Exceptions
{
    public class SocialAuthException<T> : BaseServiceException<T>
    {
        public SocialAuthException()
        {
        }
    }
}
