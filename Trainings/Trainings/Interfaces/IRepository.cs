using System.Collections.Generic;
using System.Linq;

namespace Trainings.Interfaces
{
    interface IRepository<T>
    {
        IQueryable<T> GetEntities();
        T GetEntity(int id);
        void Create(T item);
        void Create(IEnumerable<T> items);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
