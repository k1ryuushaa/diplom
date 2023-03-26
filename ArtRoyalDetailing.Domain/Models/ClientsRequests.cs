using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ArtRoyalDetailing.Domain.Models
{
    public partial class ClientsRequests
    {
        public int? IdService { get; set; }
        public int? IdClient { get; set; }
        public DateTime? DateRequest { get; set; }
        public string AutoModel { get; set; }
        public string AutoClass { get; set; }

        public virtual Users IdClientNavigation { get; set; }
        public virtual Services IdServiceNavigation { get; set; }
    }
}
