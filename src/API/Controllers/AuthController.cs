using Abstraction.IServices;
using Azure.Core;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizeService _authorizeService;
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        public AuthController(IAuthorizeService authorizeService,
            IUserService userService
            , IJwtService jwtService)
        {
            _authorizeService = authorizeService;
            _jwtService = jwtService;
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginForm form)
        {
            var currentUser = await _authorizeService.Login(form);
            if (string.IsNullOrEmpty(currentUser.ID))
            {
                return BadRequest("Invalid credentials");
            }
            var result = await _jwtService.CreateToken(form);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Invalid credentials");
            }
            return Ok(new ResultToken() { AccessToken = result });
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterForm form)
        {
            var user = await _authorizeService.Register(form);
            if (!string.IsNullOrEmpty(user.ID))
            {
                return Ok(new ResultToken()
                {
                    AccessToken = await _jwtService.CreateToken(
                    new LoginForm() { UserName = form.UserName }
                    )
                });
            }
            return BadRequest();
        }

    }
}
