using MinerAPP.Application.Interfaces;
using MinerAPP.Core.Domain;
using MinerAPP.Infrastructure.Contexts;
using MinerAPP.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Infrastructure.Repositories
{
    public class StaticDictionariesRepository : GenericRepository<StaticDictionaries>, IStaticDictionariesRepository
    {
        public StaticDictionariesRepository(AppDbContext dbContext) : base(dbContext)
        {


        }

    }
}
