using System;
using System.Collections.Generic;

#nullable disable

namespace ArtRoyalDetailing.Models
{
    public partial class WorkersSheduler
    {
        public int? IdWorker { get; set; }
        public DateTime? DateDay { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeStop { get; set; }

        public virtual User IdWorkerNavigation { get; set; }
    }
}
