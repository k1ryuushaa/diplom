using System;
using System.Collections.Generic;

#nullable disable

namespace ArtRoyalDetailing.Models
{
    public partial class Service
    {
        public int IdService { get; set; }
        public string ServiceName { get; set; }
        public int ServiceType { get; set; }

        public virtual ServiceType ServiceTypeNavigation { get; set; }
    }
}
