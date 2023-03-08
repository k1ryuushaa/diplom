using System;
using System.Collections.Generic;

#nullable disable

namespace ArtRoyalDetailing.Models
{
    public partial class ContractStatus
    {
        public ContractStatus()
        {
            Contracts = new HashSet<Contract>();
        }

        public int IdStatus { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
