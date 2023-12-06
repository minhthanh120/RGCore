using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.IServices
{
    public interface IAuthorizeService
    {
        Task<User> Login(LoginForm form);
        Task<User> Register(RegisterForm form);
    }
}
