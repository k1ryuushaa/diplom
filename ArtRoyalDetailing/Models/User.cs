using System;
using System.Collections.Generic;

#nullable disable

namespace ArtRoyalDetailing.Models
{
    public partial class User
    {
        public User()
        {
            ContractIdAdminNavigations = new HashSet<Contract>();
            ContractIdWasherNavigations = new HashSet<Contract>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserPhonenumber { get; set; }
        public int? UserRole { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }

        public virtual Role UserRoleNavigation { get; set; }
        public virtual ICollection<Contract> ContractIdAdminNavigations { get; set; }
        public virtual ICollection<Contract> ContractIdWasherNavigations { get; set; }
    }
}
