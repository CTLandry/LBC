using System;
namespace LBC.Infrastructure.Result
{
    public abstract class BaseResult 
    {
        private readonly T status;

        public BaseResult(T status)
        {
            this.status = status;
        }

        public T Status => status;
    }
}
