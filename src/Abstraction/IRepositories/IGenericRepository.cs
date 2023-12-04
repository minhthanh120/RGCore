using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
