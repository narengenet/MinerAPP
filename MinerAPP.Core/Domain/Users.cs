using MinerAPP.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Core.Domain
{
    public class Users : AuditableBaseEntity
    {

        public string Name { get; set; }
        public string Family { get; set; }
        public string Username { get; set; }
        public string Cellphone { get; set; }
        public bool IsActivated { get; set; }
        public string? ConfirmationCode { get; set; }
        public long Points { get; set; }
        public string? ProfileMediaURL { get; set; }
        public string Email { get; set; }
        public string? WalletAddress { get; set; }

        public Users()
        {

        }
        public string FullName()
        {
            return this.Name + " " + this.Family;
        }


    }
}
