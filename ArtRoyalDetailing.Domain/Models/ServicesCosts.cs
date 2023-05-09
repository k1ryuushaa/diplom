using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ArtRoyalDetailing.Domain.Models
{
    public partial class ServicesCosts
    {
        
        public int Id { get; set; }
        public int? IdService { get; set; }
        public string ClassAuto { get; set; }
        public string Cost { get; set; }

        public virtual Services IdServiceNavigation { get; set; }
    }
}
