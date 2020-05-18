using System;
using System.Collections;
using System.Threading.Tasks;

namespace LBC.Infrastructure.Logging
{
    public class Logger : ILogger
    {
        public Logger()
        {
        }

        public Task LogEvent<T>(T eventName)
        {
            throw new NotImplementedException();
        }

        public Task LogEvent<T, D>(T eventName, D data) where D : IEnumerable
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

        public Task LogToDebugger<T>(T exception)
        {
            throw new NotImplementedException();
        }
    }
}
