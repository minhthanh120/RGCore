using Abstraction.IServices;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizeService _authorizeService;
        private readonly IJwtService _jwtService;
        public AuthController(IAuthorizeService authorizeService
            , IJwtService jwtService)
        {
            _authorizeService = authorizeService;
            _jwtService = jwtService;

        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginForm form)
        {
            var currentUser = await _authorizeService.Login(form);
            if (string.IsNullOrEmpty(currentUser.ID)) {
                return BadRequest("Invalid credentials");
            }
            var result = await _jwtService.CreateToken(form);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Invalid credentials");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterForm form)
        {
            await _authorizeService.Register(form);
            return Ok();
        }
        
    }
}
