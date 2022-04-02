using System;
using System.Collections.Generic;

namespace Data.Entries
{
    public partial class ClientEntry
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; } = null!;
        public string ClientSurname { get; set; } = null!;
        public string? ClientPatronymic { get; set; }
        public string? ClientPhone { get; set; }
        public string? ClientEmail { get; set; }
        public Guid? ClientOrders { get; set; }

        public virtual OrderClientEntry? ClientOrdersNavigation { get; set; }
    }
}
