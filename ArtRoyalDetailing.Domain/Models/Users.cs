using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ArtRoyalDetailing.Domain.Models
{
    public partial class Users
    {
        public Users()
        {
            Contracts = new HashSet<Contracts>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserPhonenumber { get; set; }
        public int? UserRole { get; set; }
        public string UserLogin { get; set; }
        public string UserPasswordHash { get; set; }
        public int? UserBalance { get; set; }

        public virtual Roles UserRoleNavigation { get; set; }
        public virtual Salary Salary { get; set; }
        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
