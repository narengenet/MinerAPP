using Microsoft.Extensions.DependencyInjection;
using MinerAPP.Application.Interfaces;
using MinerAPP.Infrastructure.Repositories;
using MinerAPP.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Infrastructure
{
    public static class DependencyContainer
    {
        public static void AddIoCService(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UserRepository>();

            services.AddScoped<UsersServices, UsersServices>();
        }
    }
}
