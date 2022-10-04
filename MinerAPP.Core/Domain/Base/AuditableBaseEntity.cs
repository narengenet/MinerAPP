using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Core.Domain.Base
{
    public abstract class AuditableBaseEntity : BaseEntity
    {

        public virtual Guid? CreatedBy { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual Guid? LastModifiedBy { get; set; }
        public virtual DateTime? LastModified { get; set; }
    }
}
