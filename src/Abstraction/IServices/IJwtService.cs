using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.IServices
{
    public interface IJwtService
    {
        Task<string> CreateToken(LoginForm form);
    }
}
