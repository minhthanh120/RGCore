using Abstraction.IRepositories;
using Domain.Contexts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class AuthRepository:GenericRepository<Auth>, IAuthRepository
    {
        public AuthRepository(CoreContext context):base(context)
        {
            
        }

        public async Task<Auth> GetByIDUser(string IDUser)
        {
            return await _context.Auths.Where(a=>a.IDUser == IDUser).FirstOrDefaultAsync();
        }
    }
}
