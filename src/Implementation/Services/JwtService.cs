﻿using Abstraction;
using Abstraction.IRepositories;
using Abstraction.IServices;
using Domain.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Services
{

    public class JwtService:IJwtService
    {
        private readonly IUserService _userService;
        private readonly IAuthorizeService _authService;
        private readonly IUnitOfWorkService _unitOfWork;
        private IConfiguration _configuration;
        public JwtService(IAuthorizeService authService,
            IUnitOfWorkService unitOfWork,
            IUserService userService,
            IConfiguration configuration)
        {
            _userService = userService;
            _authService = authService;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<string> CreateToken(LoginForm form)
        {
            var user = await _unitOfWork.User.FindByUserName(form.UserName);
            if (user == null)
            {
                return string.Empty;
            }

            var auth = await _unitOfWork.Auth.GetByIDUser(user.ID);
            if (auth == null)
            {
                return string.Empty;
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.ID.ToString()),
                        new Claim("DisplayName", string.Join(" ", user.FirstName, user.MiddleName, user.LastName)),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
