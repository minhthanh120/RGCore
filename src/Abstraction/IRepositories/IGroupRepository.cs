using Domain.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.IRepositories
{
    public interface IGroupRepository:IGenericRepository<Group>
    {
        Task<IEnumerable<Group>> GetAllByJoined();

    }
}
