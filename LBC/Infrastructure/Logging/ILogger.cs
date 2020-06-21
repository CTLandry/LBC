using System;
using System.Collections;
using System.Threading.Tasks;
using LBC.Services.User.Session;

namespace LBC.Infrastructure.Logging
{
    public interface ILogger
    {
        Task LogException<T>(T exception) where T : SystemException;
        Task LogException<T>(T exception, string message) where T : SystemException;
        Task LogException<T, S>(T exception, S session, string message) where T : SystemException
                                                                        where S : ISession;
        Task LogEvent<S>(string eventName) where S : ISession;
        Task LogEvent<D>(string eventName, D data) where D : IEnumerable;
        Task LogEvent<D,S>(string eventName, D data, ISession session) where D : IEnumerable
                                                                       where S : ISession;
        Task LogToDebugger(string exceptionMessage);
        
    }
}
