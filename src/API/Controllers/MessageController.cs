using Abstraction;
using Abstraction.IServices;
using AutoMapper;
using Domain.Models.Chat;
using Domain.ViewModels;
using Helper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        //private readonly IMessa unitOfWorkService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService,
            IMapper mapper)
        {
            _mapper = mapper;
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
        public async Task<ServiceResult> Create(MessageView model)
        {
            var obj = _mapper.Map<Message>(model);
            return await _messageService.Create(obj);
        }

        // PUT api/<MessageController>/5
        [HttpPost]
        public async Task<ServiceResult> Update(MessageView model)
        {
            var obj = _mapper.Map<Message>(model);
            return await _messageService.Update(obj);
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public async Task<ServiceResult> Delete(string id)
        {
            return await _messageService.Delete(id);
        }
    }
}
