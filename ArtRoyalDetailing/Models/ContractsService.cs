using System;
using System.Collections.Generic;

#nullable disable

namespace ArtRoyalDetailing.Models
{
    public partial class ContractsService
    {
        public int? IdContract { get; set; }
        public int? IdService { get; set; }

        public virtual Contract IdContractNavigation { get; set; }
        public virtual Service IdServiceNavigation { get; set; }
    }
}
