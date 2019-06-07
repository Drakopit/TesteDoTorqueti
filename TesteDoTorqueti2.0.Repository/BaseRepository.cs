using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TesteDoTorqueti2._0.Repository.Interfaces;

namespace TesteDoTorqueti2._0.Repository
{
    public class BaseRepository<T> : IBaseRespository<T> where T : class
    {
        private readonly RepositoryContext context;
        private DbSet<T> entity = null;

        public BaseRepository(RepositoryContext context)
        {
            this.context = context;
            entity = this.context.Set<T>();
        }


        public IEnumerable<T> GetAll()
        {
            return this.entity.ToList();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> where)
        {
            return this.entity.Where(where).AsQueryable();
        }

        public void Insert(T entity)
        {
            this.entity.Add(entity);
            this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            this.entity.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = this.entity.Find(id);
            this.entity.Remove(entity);
            this.context.SaveChanges();
        }
    }
}
