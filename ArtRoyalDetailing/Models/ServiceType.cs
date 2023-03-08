using System;
using System.Collections.Generic;

#nullable disable

namespace ArtRoyalDetailing.Models
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            Services = new HashSet<Service>();
        }

        public int IdType { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
