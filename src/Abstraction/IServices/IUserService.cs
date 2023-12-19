using Domain.Models;
using Domain.ViewModels;
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
        Task<User> GetUserbyID(string idUser);
        Task<UserView> Update(UserView model);
        Task<IEnumerable<User>> SearchbyEmail(string email);
    }
}
