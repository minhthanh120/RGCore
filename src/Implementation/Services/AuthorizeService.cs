using Abstraction;
using Abstraction.IServices;
using Domain.Models;
using Domain.ViewModels;
using Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Services
{
    public class AuthorizeService:IAuthorizeService
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
            return await _unitOfWork.User.FindByUserName(form.UserName);
        }
        public async Task<User> Register(RegisterForm form)
        {
            var isExisted = await _unitOfWork.User
                .Query(u=>u.UserName == form.UserName || u.Email== u.Email)
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
            Auth auth = new Auth()
            {
                IDUser = IDUser,
                Password = Password,
                Created = DateTime.Now,
            };
            await _unitOfWork.Auth.Create(auth);
            return new SuccessResult();
        }
    }
}
