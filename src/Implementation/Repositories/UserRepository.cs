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
    public class UserRepository:GenericRepository<User>, IUserRepository
    {
        public UserRepository(CoreContext context):base(context)
        {
            
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> FindByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
