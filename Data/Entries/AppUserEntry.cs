using System;
using System.Collections.Generic;

namespace Data.Entries
{
    public partial class AppUserEntry
    {
        public AppUserEntry()
        {
            AuthorizationUsers = new HashSet<AuthorizationUserEntry>();
        }

        public Guid Id { get; set; }
        public string? UserRole { get; set; }

        public virtual ICollection<AuthorizationUserEntry> AuthorizationUsers { get; set; }
    }
}
