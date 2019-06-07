using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TesteDoTorqueti2._0.Repository.Interfaces;
using TesteDoTorqueti2._0.Service.Interfaces;

namespace TesteDoTorqueti2._0.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRespository<T> repository;
        public BaseService(IBaseRespository<T> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<T> GetAll()
        {
            return this.repository.GetAll();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> where)
        {
            return this.repository.GetByCondition(where);
        }

        public void Insert(T entity)
        {
            this.repository.Insert(entity);
        }

        public void Update(T entity)
        {
            this.repository.Update(entity);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
    }
}
