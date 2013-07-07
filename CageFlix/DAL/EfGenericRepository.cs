using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CageFlix.Models;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data;

namespace CageFlix.DAL
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private CageFlixContext context;
        private DbSet<T> dbSet;

        public EfGenericRepository(CageFlixContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public virtual T GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual T Single(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Single(predicate);
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return dbSet.SingleOrDefault(predicate);
        }

        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            return dbSet.First(predicate);
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
    }
}