using System;
namespace LBC.Services.Base
{
    public abstract class BaseService : IService, IDisposable
    {
        public abstract void Dispose();
    }
}
