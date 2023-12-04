using Abstraction.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Chat;
using Domain.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Implementation.Repositories
{
    public class MessageRepository: GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(CoreContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Message>> GetAllByIDGroup(string IDGroup)
        {
            return await _context.Messages.Where(x=>x.IDGroup == IDGroup).ToListAsync();
        }
    }
}
