using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ArtRoyalDetailing.Domain.Models
{
    public partial class Services
    {
        public int IdService { get; set; }
        public string ServiceName { get; set; }
        public int ServiceType { get; set; }

        public virtual ServiceType ServiceTypeNavigation { get; set; }
    }
}
