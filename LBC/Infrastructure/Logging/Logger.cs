using System;
using System.Collections;
using System.Threading.Tasks;
using LBC.Services.Session;

namespace LBC.Infrastructure.Logging
{
    public class Logger : ILogger
    {
        public Task LogEvent<S>(string eventName) where S : ISession
        {
            throw new NotImplementedException();
        }

        public Task LogEvent<D>(string eventName, D data) where D : IEnumerable
        {
            throw new NotImplementedException();
        }

        public Task LogEvent<D, S>(string eventName, D data, ISession session)
            where D : IEnumerable
            where S : ISession
        {
            throw new NotImplementedException();
        }

        public Task LogException<T>(T exception) where T : SystemException
        {
            throw new NotImplementedException();
        }

        public Task LogException<T>(T exception, string message) where T : SystemException
        {
            throw new NotImplementedException();
        }

        public Task LogException<T, S>(T exception, S session, string message)
            where T : SystemException
            where S : ISession
        {
            throw new NotImplementedException();
        }

        public Task LogToDebugger(string debugStatement)
        {
            throw new NotImplementedException();
        }
    }
}
