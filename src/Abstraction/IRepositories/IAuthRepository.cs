using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.IRepositories
{
    public interface IAuthRepository:IGenericRepository<Auth>
    {
        Task<Auth> GetByIDUser(string IDUser);
    }
}
