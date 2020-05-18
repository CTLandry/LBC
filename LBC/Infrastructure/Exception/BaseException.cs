using System;
using System.Collections.Generic;
using LBC.Domain.SocialAuth.Exceptions;
using LBC.Infrastructure.Logging;
using TinyIoC;

namespace LBC.Infrastructure.Exception
{

    public abstract class BaseException : System.Exception
    {
        private readonly ILogger Log;

        public BaseException()
        {
            this.Log = TinyIoCContainer.Current.Resolve<ILogger>();
            var logDetails = new Dictionary<string, string>();

            //Session Data
            //Time
            //Exception
            //Inner Message
            
        }
    }

}