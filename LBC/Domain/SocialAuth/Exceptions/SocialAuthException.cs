using System;
using LBC.Domain.Base;
using LBC.Infrastructure.Logging;
using LBC.Services.Session;

namespace LBC.Domain.SocialAuth.Exceptions
{
    public class SocialAuthException<T> : BaseDomainException<T> where T : SystemException
    {
        public SocialAuthException(T exception) : base(exception)
        {
        }
    }
}
