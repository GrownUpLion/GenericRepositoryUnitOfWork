using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T>  where T : IEntity
    {
        void Save(T obj);
        void Update(T obj);
        void Delete(T obj);
        T GetById<T>(int objId);
        T GetByName<T>(string property,string name);
        IEnumerable<T> GetAll<T>(int startIndex, int count);
    }
}
