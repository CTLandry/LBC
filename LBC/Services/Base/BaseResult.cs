using System;
namespace LBC.Services.Base
{
    public abstract class BaseResult<TStatus>
    {
        public readonly TStatus Status;

        public BaseResult(TStatus status)
        {
            this.Status = status;
        }

       
    }
}
