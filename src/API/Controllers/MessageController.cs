using Abstraction;
using Abstraction.IServices;
using Domain.Models.Chat;
using Helper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        //private readonly IMessa unitOfWorkService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        // GET: api/<MessageController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // GET api/<MessageController>/seachKey?
        [HttpGet("{searchKey}")]
        public async Task<IEnumerable<Message>> Search(string searchKey)
        {
            return await _messageService.Search(searchKey);
        }

        // POST api/<MessageController>
        [HttpPost]
        public async Task<ServiceResult> Create(Message model)
        {
            model.ID = null;
            return await _messageService.Create(model);
        }

        // PUT api/<MessageController>/5
        [HttpPost]
        public async Task<ServiceResult> Update(Message model)
        {
            return await _messageService.Update(model);
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public async Task<ServiceResult> Delete(string id)
        {
            return await _messageService.Delete(id);
        }
    }
}
