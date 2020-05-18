using System;
using LBC.Infrastructure.Logging;
using LBC.Services.Session;
using TinyIoC;

namespace LBC.Infrastructure.Logic
{
    public abstract class BaseLogic
    {
        private readonly ILogger Logger;
        private readonly ISession Session;

        public BaseLogic()
        {
            this.Logger = Logger == null ? TinyIoCContainer.Current.Resolve<ILogger>() : this.Logger;
            this.Session = Session == null ? TinyIoCContainer.Current.Resolve<ISession>() : this.Session;
        }
    }
}
