using System;
using LBC.Infrastructure.Exception;

namespace LBC.Domain.Base
{
    public class BaseDomainException<T> : BaseException<T>
    {
        public BaseDomainException()
        {
        }
    }
}
