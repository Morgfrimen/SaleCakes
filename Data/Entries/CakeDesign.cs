using System;
using System.Collections.Generic;

namespace Data.Entries
{
    public partial class CakeDesign
    {
        public Guid Id { get; set; }
        public Guid? CakeId { get; set; }
        public Guid? TierId { get; set; }

        public virtual CakeEntry? Cake { get; set; }
        public virtual TierEntry? Tier { get; set; }
    }
}
