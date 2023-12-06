using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.IRepositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> FindByUserName(string userName);
        Task<User> FindByEmail(string email);
    }
}
