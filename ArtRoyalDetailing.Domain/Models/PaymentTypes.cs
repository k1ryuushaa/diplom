using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ArtRoyalDetailing.Domain.Models
{
    public partial class PaymentTypes
    {
        public PaymentTypes()
        {
            Contracts = new HashSet<Contracts>();
        }

        public int IdType { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
