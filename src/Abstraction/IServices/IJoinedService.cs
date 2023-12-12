using Domain.Models.Chat;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.IServices
{
    public interface IJoinedService
    {
        Task<ServiceResult> Create(string idGroup, IEnumerable<string> IDUsers);
        Task<ServiceResult> Update(Joined model);
        Task<ServiceResult> Delete(string idGroup,  IEnumerable<string> IDUsers);
        Task<Joined> GetByID(string id);
        Task<IEnumerable<Joined>> GetbyIDGroup(string IDGroup);
        Task<IEnumerable<Joined>> Search(string searchkey);
    }
}
