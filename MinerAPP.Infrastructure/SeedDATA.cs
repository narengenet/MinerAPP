using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MinerAPP.Core.Domain;
using MinerAPP.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Infrastructure
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {


            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {

                if (!context.Users.Any())
                {
                    var users = new List<Users>
                    {
                        new Users()
                        {
                            Name="Sina",
                            Family="Sarparast"
                        },
                        new Users()
                        {
                             Name="Rahman",
                             Family="Dabouei"
                        }
                    };

                    users.ForEach(u => context.Users.Add(u));
                    context.SaveChanges();
                }
            }
        }
    }
}
