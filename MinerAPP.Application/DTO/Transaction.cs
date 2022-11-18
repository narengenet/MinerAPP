using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Application.DTO
{
    public class Transaction
    {
        public string date { get; set; }
        public string amount { get; set; }
        public string confirmed { get; set; }
        public string hash { get; set; }
        public bool isdeposit { get; set; }
    }
}
