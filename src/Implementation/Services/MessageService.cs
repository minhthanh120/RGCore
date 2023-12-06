using Abstraction;
using Abstraction.IServices;
using Domain.Models.Chat;
using Helper;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<MessageService> _logger;
        public MessageService(
            IUnitOfWorkService uowService,
            ILogger<MessageService> logger)
        {
            _uowService = uowService;
            _logger = logger;
        }

        public async Task<ServiceResult> Create(Message model)
        {
            try
            {
                await _uowService.Message.Create(model);
                await _uowService.SaveChanges();
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new FailedResult();
            }
        }

        public async Task<ServiceResult> Update(Message model)
        {
            try
            {
                var result = await _uowService.Message.GetByID(model.ID);
                if (result != null)
                {
                    return new FailedResult("This Message has been deleted or not exist");
                }
                result.Updated = DateTime.Now;
                result.Content = model.Content;
                await _uowService.SaveChanges();
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new FailedResult();
            }
        }

        public async Task<ServiceResult> Delete(string ID)
        {
            try
            {
                var result = await _uowService.Message.GetByID(ID);
                if (result != null)
                {
                    return new FailedResult("This Message has been deleted or not exist");
                }
                await _uowService.Message.Delete(result);
                await _uowService.SaveChanges();
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new FailedResult();
            }
        }

        public async Task<IEnumerable<Message>> Search(string searchkey)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchkey))
                {
                    return await _uowService.Message.Search(m=>m.Content.ToLower()
                        .Contains(searchkey.ToLower()));
                }
                return new List<Message>();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new List<Message>();
            }
        }
    }
}
