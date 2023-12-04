using Abstraction.IRepositories;
using Domain.Contexts;
using Domain.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class GroupRepository:GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(CoreContext context):base(context)
        {
            
        }

        public async Task<IEnumerable<Group>> GetAllByJoined()
        {
            throw new NotImplementedException();
        }
    }
}
