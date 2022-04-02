using System;
using System.Collections.Generic;

namespace Data.Entries
{
    public partial class OrderClientEntry
    {
        public OrderClientEntry()
        {
            Clients = new HashSet<ClientEntry>();
        }

        public Guid Id { get; set; }
        public DateTime OrderCreatedAt { get; set; }
        public string OrderAdress { get; set; } = null!;
        public Guid? OrderCake { get; set; }
        public Guid? OrderCondites { get; set; }
        public Guid? OrderEmoloyee { get; set; }
        public decimal OrderSeller { get; set; }

        public virtual CakeEntry? OrderCakeNavigation { get; set; }
        public virtual AuthorizationUserEntry? OrderConditesNavigation { get; set; }
        public virtual AuthorizationUserEntry? OrderEmoloyeeNavigation { get; set; }
        public virtual ICollection<ClientEntry> Clients { get; set; }
    }
}
