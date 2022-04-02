using System;
using System.Collections.Generic;

namespace Data.Entries
{
    public partial class CakeEntry
    {
        public CakeEntry()
        {
            OrderClients = new HashSet<OrderClientEntry>();
        }

        public Guid Id { get; set; }
        public decimal Weight { get; set; }
        public Guid Tiers { get; set; }

        public virtual TierEntry TiersEntryNavigation { get; set; } = null!;
        public virtual ICollection<OrderClientEntry> OrderClients { get; set; }
    }
}
