using System;
using System.Collections.Generic;

namespace LBC.Data
{
    public abstract class DataRepository : IDataRepository
    {
        public abstract T Delete<T>(T parameter);
        public abstract T Get<T>();
        public abstract IEnumerable<T> GetAll<T>();
        public abstract T Insert<T>(T parameter);
        public abstract T Update<T>(T parameter);
        
    }
}
