using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ArtRoyalDetailing.Domain.Models
{
    public partial class WorkersSheduler
    {
        public int? IdWorker { get; set; }
        public DateTime? DateDay { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeStop { get; set; }

        public virtual Users IdWorkerNavigation { get; set; }
    }
}
