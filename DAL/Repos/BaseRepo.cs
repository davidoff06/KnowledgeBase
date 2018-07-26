using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repos
{

    public abstract class BaseRepo<T>: IRepo<T> where T : class, new()
    {
        protected KnowledgeAuditContext Context;

        public BaseRepo(KnowledgeAuditContext db)
        {
            Context = db;
        }

        protected DbSet<T> Table;

        public T GetOne(int? id) => Table.Find(id);

        public IQueryable<T> Get() => Table.AsQueryable();

        public void Add(T entity)
        {
            Table.Add(entity);
        }

        public void AddRange(IList<T> entities)
        {
            Table.AddRange(entities);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Table.AddRange(entities);
        }

        public void Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Save(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

    }

}
