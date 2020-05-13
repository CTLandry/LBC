using System;
namespace LBC.Services.Base
{
    public abstract class BaseResult 
    {
        public readonly BaseResultStatus.Status Status;

        public BaseResult(BaseResultStatus.Status status)
        {
            this.Status = status;
        }

       
    }
}
