using Abstraction;
using Abstraction.IServices;
using Domain.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Services
{
    public class MessageService:IMessageService
    {
        private readonly IUnitOfWorkService _uowService;
        public MessageService(IUnitOfWorkService uowService)
        {
            _uowService = uowService;
        }

        public async Task<Message> Create(Message model)
        {
            var result = await _uowService.Message.Create(model);
            await _uowService.SaveChanges();
            return result;
        }
    }
}
