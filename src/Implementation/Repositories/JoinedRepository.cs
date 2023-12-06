using Abstraction.IRepositories;
using Domain.Contexts;
using Domain.Models.Chat;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class JoinedRepository : GenericRepository<Joined>, IJoinedRepository
    {
        public JoinedRepository(CoreContext context) :base(context)
        {
            
        }
        public async Task<IEnumerable<Joined>> GetJoinedsByIDGroup(string iDGroup)
        {
            return await _context.Joineds.Where(j => j.IDGroup == iDGroup).ToListAsync();
        }
    }
}
