using System;
using LBC.Configuration.Configs;
using LBC.Infrastructure.Logging;
using LBC.Services.User.Session;

namespace LBC.Services._Base
{
    public class BaseService 
    {
        protected readonly ILogger logger;
        protected readonly IConfiguration config;
        protected readonly ISession session;

        public BaseService(ILogger logger, IConfiguration config, ISession session)
        {
            this.logger = logger;
            this.config = config;
            this.session = session;
        }
    }
}
