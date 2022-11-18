﻿using MinerAPP.Application.Interfaces;
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
    public class TransactionsRepository : GenericRepository<Transactions>, ITransactionsRepository
    {
        public TransactionsRepository(AppDbContext dbContext) : base(dbContext)
        {


        }

    }
}

