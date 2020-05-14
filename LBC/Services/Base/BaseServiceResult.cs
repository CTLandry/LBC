using System;
using LBC.Infrastructure.Result;

namespace LBC.Services.Base
{
    public class BaseServiceResult<TResult, TMessage> : BaseResult<TResult, TMessage>
    {
        public BaseServiceResult(TResult result, TMessage message) : base(result, message)
        {
        }
    }
}
