using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CageFlix.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, string includeProperties = "");
        T GetByID(object id);
        T Single(Expression<Func<T, bool>>  predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        
        void Insert(T entity);
        void Delete(object id);
        void Delete(T entity);
    }
}
