using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);

        T GetById(int id);

        void Create(T entity);

        void CreateWithoutSave(T entity);

        
        void Update(T entity);

        void Delete(T entity);

        int Count(Func<T, bool> predicate);

    }
}
