using System;
namespace LBC.Infrastructure.Result
{
    public abstract class BaseResult<T> 
    {
        private T _status;
        public T Status
        {
            get => _status;
        }

        public BaseResult(T status)
        {
            _status = status;
        }
      
    }
}
