using MinerAPP.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Core.Domain
{
    public class UsersLogins : AuditableBaseEntity
    {
        public Guid User { get; set; }
        public string IMEI { get; set; }
        public string DeviceModel { get; set; }
    }
}
