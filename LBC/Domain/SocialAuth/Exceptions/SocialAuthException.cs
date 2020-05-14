using System;
using LBC.Domain.Base;

namespace LBC.Domain.SocialAuth.Exceptions
{
    public class SocialAuthException<T> : BaseDomainException<T>
    {
        public SocialAuthException()
        {
        }
    }
}
