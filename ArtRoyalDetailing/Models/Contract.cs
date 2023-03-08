using System;
using System.Collections.Generic;

#nullable disable

namespace ArtRoyalDetailing.Models
{
    public partial class Contract
    {
        public int IdContract { get; set; }
        public string ClientName { get; set; }
        public string AutoModel { get; set; }
        public string AutoClass { get; set; }
        public DateTime? DateContract { get; set; }
        public int? StatusContract { get; set; }
        public int? PaymentType { get; set; }
        public int? IdAdmin { get; set; }
        public int? IdWasher { get; set; }
        public int? EndCost { get; set; }

        public virtual User IdAdminNavigation { get; set; }
        public virtual User IdWasherNavigation { get; set; }
        public virtual PaymentType PaymentTypeNavigation { get; set; }
        public virtual ContractStatus StatusContractNavigation { get; set; }
    }
}
