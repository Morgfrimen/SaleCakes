using System;
using System.Collections.Generic;

namespace Data.Entries
{
    public partial class TierEntry
    {
        public TierEntry()
        {
            CakeDesigns = new HashSet<CakeDesign>();
        }

        public Guid Id { get; set; }
        public Guid? Stuffing { get; set; }
        public Guid? Decor { get; set; }
        public Guid? Shortcake { get; set; }

        public virtual DecorEntry? DecorNavigation { get; set; }
        public virtual ShortcakeEntry? ShortcakeNavigation { get; set; }
        public virtual StuffingEntry? StuffingNavigation { get; set; }
        public virtual ICollection<CakeDesign> CakeDesigns { get; set; }
    }
}
