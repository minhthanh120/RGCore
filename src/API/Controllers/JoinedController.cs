using Abstraction;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinedController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public JoinedController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        // GET: api/<JoinedController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<JoinedController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JoinedController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JoinedController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JoinedController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
