using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MyBusinessApp.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
    }
}