using System;
namespace LBC.Services.Base
{
    public abstract class BaseResult<TResultStatus>
    {
        public readonly TResultStatus Status;

        public BaseResult(TResultStatus status)
        {
            this.Status = status;
        }
    }
}
