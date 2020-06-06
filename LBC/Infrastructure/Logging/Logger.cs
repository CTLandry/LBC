using System;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;
using LBC.Services.User.Session;

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

        public async Task LogToDebugger(string exceptionMessage)
        {
            await Task.Run(() =>
            {
                Debug.WriteLine("----------Error----------");
                Debug.WriteLine($"Time: {DateTime.Now}");
                Debug.WriteLine($"Error: {exceptionMessage}");
                Debug.WriteLine("-------------------------");
            });
           
        }
    }
}
