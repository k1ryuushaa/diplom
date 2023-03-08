using System;
using System.Collections.Generic;

#nullable disable

namespace ArtRoyalDetailing.Models
{
    public partial class ClientsRequest
    {
        public int? IdService { get; set; }
        public int? IdClient { get; set; }
        public DateTime? DateRequest { get; set; }
        public string AutoModel { get; set; }
        public string AutoClass { get; set; }

        public virtual User IdClientNavigation { get; set; }
        public virtual Service IdServiceNavigation { get; set; }
    }
}
