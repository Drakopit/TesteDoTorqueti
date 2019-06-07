using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TesteDoTorqueti2._0.Repository.Interfaces
{
    public interface IBaseRespository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> where);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
