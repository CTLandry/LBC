using System;
using System.Collections;
using System.Threading.Tasks;


namespace LBC.Infrastructure.Logging
{
    public interface ILogger
    {
        Task LogException<T>(T exception) where T : SystemException;
        Task LogException<T>(T exception, string message) where T : SystemException;
        Task LogEvent<T>(T eventName);
        Task LogToDebugger<T>(T exception);
        Task LogEvent<T, D>(T eventName, D data) where D : IEnumerable;
    }
}
