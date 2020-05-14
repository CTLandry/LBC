using System;
using LBC.Infrastructure.Exception;

namespace LBC.Services.Base
{
    public class BaseServiceException<T> : BaseException<T>
    {
        public BaseServiceException()
        {
        }
    }
}
