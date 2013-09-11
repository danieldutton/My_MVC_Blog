using System.Collections.Generic;

namespace DansBlog.Repository.Interfaces
{
    public interface IEntityRepository<T>
    {
        List<T> All { get; }
        T Find(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);      
    }
}
