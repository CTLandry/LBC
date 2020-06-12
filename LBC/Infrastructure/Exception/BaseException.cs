using System;
using LBC.Infrastructure.Logging;
using LBC.Services.User.Session;


namespace LBC.Infrastructure.Exception
{

    public abstract class BaseException<T> where T : SystemException
    {
        private readonly ILogger Logger;
        private readonly ISession Session;
        private T Exception;

        public BaseException(T exception)
        {
            //this.Logger = Logger == null ? TinyIoCContainer.Current.Resolve<ILogger>() : this.Logger;
            //this.Session = Session == null ? TinyIoCContainer.Current.Resolve<ISession>() : this.Session;
            Exception = exception;

            //TODO log data about the exception
            //Logger.LogException<T>(exception);
            
        }
    }

}