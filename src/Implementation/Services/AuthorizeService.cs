using Abstraction;
using Abstraction.IServices;
using Domain.Models;
using Domain.ViewModels;
using Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Helper.Helper;
namespace Implementation.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IUnitOfWorkService _unitOfWork;
        private readonly IUserService _userService;


        public AuthorizeService(IUnitOfWorkService unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;

        }

        public async Task<User> Login(LoginForm form)
        {
            var user = await _unitOfWork.User.FindByUserName(form.UserName);
            if (user == null)
            {
                return new User();
            }
            
            var auth = await _unitOfWork.Auth.GetByIDUser(user.ID);
            if (auth == null)
            {
                return new User();
            }
            var validPwd = VerifyPassword(form.Password, auth.Password, auth.Salt);
            if (!validPwd)
            {
                return new User();
            }
            return await _unitOfWork.User.FindByUserName(form.UserName);
        }
        public async Task<User> Register(RegisterForm form)
        {
            var isExisted = await _unitOfWork.User
                .Query(u => u.UserName == form.UserName || u.Email == form.Email)
                .Result
                .AnyAsync();
            if (isExisted)
            {
                return new User();
            }
            User user = new User()
            {
                Created = DateTime.Now,
                FirstName = form.FirstName,
                MiddleName = form.MiddleName,
                LastName = form.LastName,
                Email = form.Email,
                UserName = form.UserName
            };
            var result = await _userService.Create(user);
            var serviceResult = await Create(result.ID, form.Password);
            return result;
        }
        public async Task<ServiceResult> Create(string IDUser, string Password)
        {
            byte[] salt = Encoding.UTF8.GetBytes(IDUser);
            string password = HashPasword(Password, out salt);
            Auth auth = new Auth()
            {
                IDUser = IDUser,
                Password = password,
                Created = DateTime.Now,
                Salt = salt,
            };
            await _unitOfWork.Auth.Create(auth);
            await _unitOfWork.SaveChanges();
            return new SuccessResult();
        }

        
    }
}
