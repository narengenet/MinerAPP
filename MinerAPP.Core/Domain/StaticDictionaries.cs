using MinerAPP.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Core.Domain
{
    public class StaticDictionaries : AuditableBaseEntity
    {
        public string TheName { get; set; }
        public string TheValue { get; set; }

    }
}
