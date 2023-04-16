using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ArtRoyalDetailing.Domain.Models
{
    public partial class ContractsServices
    {
        public int IdContractService { get; set; }
        public int? IdContract { get; set; }
        public int? IdService { get; set; }
        public int? IdWasher { get; set; }
        public int? Cost { get; set; }

        public virtual Contracts IdContractNavigation { get; set; }
        public virtual Services IdServiceNavigation { get; set; }
        public virtual Users IdWasherNavigation { get; set; }
    }
}
