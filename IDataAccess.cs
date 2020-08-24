using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC18_S1
{
    public interface IDataAccess<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);       
    }
}
