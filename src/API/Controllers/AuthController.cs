using Abstraction.IServices;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Login(LoginForm form)
        {
            var result = await _jwtService.CreateToken(form);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Invalid credentials");
            }
            return Ok(result);
        }
        public async Task<IActionResult> Register(RegisterForm form)
        {
            await _authorizeService.Register(form);
            return Ok();
        }
        
    }
}
