using Domain.Models.Chat;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.IServices
{
    public interface IMessageService
    {
        Task<ServiceResult> Create(Message model);
        Task<ServiceResult> Update(Message model);
        Task<ServiceResult> Delete(string ID);
        Task<IEnumerable<Message>> Search(string searchkey);
    }
}
