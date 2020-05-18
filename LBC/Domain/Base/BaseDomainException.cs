using System;
using LBC.Infrastructure.Exception;
using LBC.Infrastructure.Logging;
using LBC.Services.Session;

namespace LBC.Domain.Base
{
    public abstract class BaseDomainException<T> : BaseException<T> where T : SystemException
    {
        public BaseDomainException(T exception) : base(exception)
        {
        }
    }
}
