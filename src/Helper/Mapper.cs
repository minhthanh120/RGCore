using AutoMapper;
using Domain.Models;
using Domain.Models.Chat;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Message, MessageView>();
            CreateMap<MessageView, Message>();

            CreateMap<Group, GroupView>();
            CreateMap<GroupView, Group>();

            CreateMap<Joined, JoinedView>();
            CreateMap<JoinedView, Joined>();

            CreateMap<User, UserView>();
            CreateMap<UserView, User>();
        }
    }
}
