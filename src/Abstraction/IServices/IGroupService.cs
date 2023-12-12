using Domain.Models.Chat;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.IServices
{
    public interface IGroupService
    {
        Task<ServiceResult> Create(Group model);
        Task<ServiceResult> Update(Group model);
        Task<ServiceResult> Delete(string IDGroup);
        Task<Group> GetByID(string IDGroup);
        Task<IEnumerable<Group>> GetGroupJoined();
        Task<IEnumerable<Group>> Search(string searchkey);

    }
}
