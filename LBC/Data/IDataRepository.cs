using System;
using System.Collections.Generic;

namespace LBC.Data
{
    public interface IDataRepository
    {
        IEnumerable<T> GetAll<T>();
        T Get<T>();
        T Insert<T>(T parameter);
        T Update<T>(T parameter);
        T Delete<T>(T parameter);
    }
}
