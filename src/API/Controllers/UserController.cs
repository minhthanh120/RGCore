using Abstraction.IServices;
using AutoMapper;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        [Route("~/api/[controller]")]
        public async Task<IActionResult> Get()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return BadRequest("Invalid credentials");
            var user = await _userService.GetUserbyID(userId);
            var result = _mapper.Map<UserView>(user);
            return Ok(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{searchKey}")]
        public async Task<IActionResult> searchbyEmail(string searchKey)
        {
            var result = await _userService.SearchbyEmail(searchKey);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(UserView model)
        {
            return Ok(await _userService.Update(model));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
