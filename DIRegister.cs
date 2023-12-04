using Abstraction.IRepositories;
using Implementation.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGCore
{
    public static class DIRegister
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IMessageRepository, MessageRepository>();
        }
    }
}
