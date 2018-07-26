using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<T>
    {
        void Add(T entity);
        void AddRange(IList<T> entities);
        void Delete(T entity);
        void Update(T entity);
        T GetOne(int? id);
        IQueryable<T> Get();
        void Save(T entity);
    }
}
