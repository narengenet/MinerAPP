using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Application
{
    public static class ServicesExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            // Setting AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // we can add other services here
        }
    }
}
