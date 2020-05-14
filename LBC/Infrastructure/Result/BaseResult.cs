using System;
namespace LBC.Infrastructure.Result
{
    public abstract class BaseResult<TResult, TMessage> 
    {
        private readonly TResult Result;
        private readonly TMessage Message;

        public BaseResult(TResult result, TMessage message)
        {
            this.Result = result;
            this.Message = message;
        }

    }
}
