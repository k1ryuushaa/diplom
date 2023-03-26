using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ArtRoyalDetailing.Domain.Models
{
    public partial class Salary
    {
        public int WorkerId { get; set; }
        public DateTime? DateSalary { get; set; }
        public int? Salary1 { get; set; }

        public virtual Users Worker { get; set; }
    }
}
