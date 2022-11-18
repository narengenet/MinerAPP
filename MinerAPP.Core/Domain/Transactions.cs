using MinerAPP.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Core.Domain
{
    public class Transactions : AuditableBaseEntity
    {
        public Guid UserID { get; set; }
        public int Amount { get; set; }
        public string TheHash { get; set; }
        public string TheWallet { get; set; }
        public bool Confirmed { get; set; }
        public bool IsDeposit { get; set; }
    }
}
