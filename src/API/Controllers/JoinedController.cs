using Abstraction;
using Abstraction.IServices;
using Helper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinedController : ControllerBase
    {
        //private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IJoinedService _joinedService;
        public JoinedController(IJoinedService joinedService)
        {
            _joinedService = joinedService;
        }

        // GET api/<JoinedController>/5
        [HttpGet("{idGroup}")]
        public async Task<IActionResult> GetJoinedMember(string idGroup)
        {
            if(!string.IsNullOrEmpty(idGroup))
            {
                var result = await _joinedService.GetbyIDGroup(idGroup);
                return Ok(result);
            }
            return BadRequest();
        }
        // GET api/<JoinedController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyID(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                await _joinedService.GetByID(id);
            }
            return BadRequest();
        }

        // POST api/<JoinedController>
        //[HttpPost]
        //public void Post(  string value)
        //{
        //}

        // PUT api/<JoinedController>/5
        [HttpPut("{idGroup}")]
        public async Task<IActionResult> Put(string idGroup, IEnumerable<string> IDUsers)
        {
            if (!string.IsNullOrEmpty(idGroup))
            {
                var rsservice = await _joinedService.Create(idGroup, IDUsers);
                if(rsservice.GetType() == typeof(SuccessResult))
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        // DELETE api/<JoinedController>/5
        [HttpDelete("{idGroup}")]
        public async Task<IActionResult> Delete(string idGroup, IEnumerable<string> IDUsers)
        {
            if (!string.IsNullOrEmpty(idGroup))
            {
                var rsservice = await _joinedService.Delete(idGroup, IDUsers);
                if (rsservice.GetType() == typeof(SuccessResult))
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
