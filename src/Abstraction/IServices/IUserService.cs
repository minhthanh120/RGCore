using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.IServices
{
    public interface IUserService
    {
        Task<User> Create(User user);
    }
}
