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
    public class GroupController : ControllerBase
    {
        //private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }


        // GET api/<GroupController>/5
        [HttpGet("{id}")]
        public async Task<Group> Get(string id)
        {
            return await _groupService.GetByID(id);
        }

        // POST api/<GroupController>
        [HttpPost]
        public async Task<ServiceResult> Create(Group model)
        {
            return await _groupService.Create(model);
        }

        // DELETE api/<GroupController>/5
        [HttpDelete("{id}")]
        public async Task<ServiceResult> Delete(string id)
        {
            return await _groupService.Delete(id);
        }
        [HttpGet("{searchkey}")]
        public async Task<IActionResult> Search(string searchkey)
        {
            if(!string.IsNullOrEmpty(searchkey))
            {
                var result = await _groupService.Search(searchkey);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }
    }
}
