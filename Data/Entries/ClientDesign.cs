using System;
using System.Collections.Generic;

namespace Data.Entries
{
    public partial class ClientDesign
    {
        public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? OrderId { get; set; }

        public virtual ClientEntry? Client { get; set; }
        public virtual OrderClientEntry? Order { get; set; }
    }
}
