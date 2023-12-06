using Abstraction.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IUnitOfWorkService
    {
        public Task SaveChanges();
        IMessageRepository Message {  get; set; }
        IGroupRepository Group { get; set; }
        IJoinedRepository Joined { get; set; }
        IUserRepository User { get; set; }
        IAuthRepository Auth { get; set; }
    }
}
