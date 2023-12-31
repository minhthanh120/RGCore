﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Abstraction.IRepositories;
using Domain.Contexts;
namespace Implementation
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly CoreContext _context;
        public UnitOfWorkService(CoreContext context,
            IMessageRepository messageRepository,
            IGroupRepository groupRepository,
            IJoinedRepository joinedRepository,
            IUserRepository user,
            IAuthRepository auth)
        {
            _context = context;
            Message = messageRepository;
            Group = groupRepository;
            Joined = joinedRepository;
            User = user;
            Auth = auth;
        }

        public IMessageRepository Message { get; set; }
        public IGroupRepository Group { get; set; }
        public IJoinedRepository Joined {  get; set; }
        public IUserRepository User { get; set; }
        public IAuthRepository Auth { get; set; }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
