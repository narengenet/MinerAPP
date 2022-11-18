using MinerAPP.Application.Interfaces.Base;
using MinerAPP.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Application.Interfaces
{
    public interface ITransactionsRepository : IGenericRepository<Transactions>
    {
    }
}
