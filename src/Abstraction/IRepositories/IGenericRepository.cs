using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> Delete(T entity);
        Task<T> GetByID(string ID);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> Query(Expression<Func<T, bool>> predicate);
    }
}
