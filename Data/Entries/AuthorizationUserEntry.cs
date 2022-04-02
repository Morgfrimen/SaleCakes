using System;
using System.Collections.Generic;

namespace Data.Entries
{
    public partial class AuthorizationUserEntry
    {
        public AuthorizationUserEntry()
        {
            OrderClientOrderConditesNavigations = new HashSet<OrderClientEntry>();
            OrderClientOrderEmoloyeeNavigations = new HashSet<OrderClientEntry>();
        }

        public Guid Id { get; set; }
        public Guid? UserGuid { get; set; }
        public string UserLogin { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual AppUserEntry? UserGu { get; set; }
        public virtual EmployeeEntry? Employee { get; set; }
        public virtual ICollection<OrderClientEntry> OrderClientOrderConditesNavigations { get; set; }
        public virtual ICollection<OrderClientEntry> OrderClientOrderEmoloyeeNavigations { get; set; }
    }
}
