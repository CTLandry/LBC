using System;
using LBC.Infrastructure.Result;

namespace LBC.Services.Base
{
    public class BaseDomainResult<TResult, TMessage> : BaseResult<TResult, TMessage>
    {
        public BaseDomainResult(TResult result, TMessage message) : base(result, message)
        {
        }
    }
}
