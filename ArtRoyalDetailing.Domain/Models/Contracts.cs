using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ArtRoyalDetailing.Domain.Models
{
    public partial class Contracts
    {
        public int IdContract { get; set; }
        public string ClientNumber { get; set; }
        public string AutoClass { get; set; }
        public DateTime? DateContract { get; set; }
        public TimeSpan? TimeContract { get; set; }
        public int? StatusContract { get; set; }
        public int? IdAdmin { get; set; }
        public int? EndCost { get; set; }

        public virtual Users IdAdminNavigation { get; set; }
        public virtual ContractStatuses StatusContractNavigation { get; set; }
    }
}
