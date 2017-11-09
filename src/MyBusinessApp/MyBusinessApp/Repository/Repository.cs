using MyBusinessApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MyBusinessApp.Repository
{
    class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext entities = null;
        IDbSet<T> _dbSet;

        public Repository(ApplicationDbContext _entities)
        {
            entities = _entities;
            _dbSet = entities.Set<T>();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Where(predicate);
            }

            return _dbSet.AsEnumerable();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
            ((IObjectContextAdapter)entities).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}