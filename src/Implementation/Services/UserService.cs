using Abstraction;
using Abstraction.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWorkService _unitOfWork;
        public UserService(IUnitOfWorkService unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                return new User();
            }
        }
    }
}
