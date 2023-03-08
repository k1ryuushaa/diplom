using System;
using System.Collections.Generic;

#nullable disable

namespace ArtRoyalDetailing.Models
{
    public partial class ServicesCost
    {
        public int? IdService { get; set; }
        public string ClassAuto { get; set; }
        public string Cost { get; set; }

        public virtual Service IdServiceNavigation { get; set; }
    }
}
