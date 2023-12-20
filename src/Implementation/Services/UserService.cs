using Abstraction;
using Abstraction.IServices;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Implementation.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWorkService _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _user;

        private readonly ILogger<UserService> _logger;
        public UserService(IUnitOfWorkService unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<User> Create(User user)
        {
            try
            {
                await _unitOfWork.User.Create(user);
                await _unitOfWork.SaveChanges();
                return user;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new User();
            }
        }

        public async Task<User> GetUserbyID(string idUser)
        {
            try
            {
                return await _unitOfWork.User.GetByID(idUser);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new User();
            }
        }

        public async Task<IEnumerable<User>> Search(string searchkey)
        {
            try
            {
                searchkey = searchkey.ToLower();
                return await _unitOfWork.User.Search(
                    u => u.Email.ToLower()
                    .Contains(searchkey)
                    || u.UserName.ToLower().Contains(searchkey)
                    || (u.FirstName + u.MiddleName + u.LastName).ToLower().Contains(searchkey));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<IEnumerable<User>> SearchbyEmail(string email)
        {
            try
            {
                return await _unitOfWork.User.Search(
                    u=>u.Email.ToLower()
                    .Contains(email.ToLower()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<UserView> Update(UserView model)
        {
            try
            {
                string userId = _user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var user = await _unitOfWork.User.GetByID(userId);
                model.Created = user.Created;
                _mapper.Map(model, user);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<UserView>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }
    }
}
