using System;
using System.Collections.Generic;

namespace Data.Entries
{
    public partial class CakeEntry
    {
        public CakeEntry()
        {
            CakeDesigns = new HashSet<CakeDesign>();
            OrderClients = new HashSet<OrderClientEntry>();
        }

        public Guid Id { get; set; }
        public decimal Weight { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CakeDesign> CakeDesigns { get; set; }
        public virtual ICollection<OrderClientEntry> OrderClients { get; set; }
    }
}
