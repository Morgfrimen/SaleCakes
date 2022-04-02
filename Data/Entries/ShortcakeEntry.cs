﻿using System;
using System.Collections.Generic;

namespace Data.Entries
{
    public partial class ShortcakeEntry
    {
        public ShortcakeEntry()
        {
            Tiers = new HashSet<TierEntry>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<TierEntry> Tiers { get; set; }
    }
}
