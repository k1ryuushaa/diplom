using System;
using System.Collections.Generic;

#nullable disable

namespace ArtRoyalDetailing.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Contracts = new HashSet<Contract>();
        }

        public int IdType { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
