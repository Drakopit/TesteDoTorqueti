using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TesteDoTorqueti2._0.Service.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> where);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
