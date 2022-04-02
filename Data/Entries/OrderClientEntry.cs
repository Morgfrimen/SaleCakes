namespace Data.Entries;

internal class OrderClientEntry
{
    internal OrderClientEntry()
    {
        ClientDesigns = new HashSet<ClientDesign>();
        Clients = new HashSet<ClientEntry>();
    }

    internal Guid Id { get; set; }
    internal DateTime OrderCreatedAt { get; set; }
    internal string OrderAdress { get; set; } = null!;
    internal Guid? OrderCake { get; set; }
    internal Guid? OrderCondites { get; set; }
    internal Guid? OrderEmoloyee { get; set; }
    internal decimal OrderSeller { get; set; }

    internal virtual CakeEntry OrderCakeNavigation { get; set; }
    internal virtual AuthorizationUserEntry OrderConditesNavigation { get; set; }
    internal virtual AuthorizationUserEntry OrderEmoloyeeNavigation { get; set; }
    internal virtual ICollection<ClientDesign> ClientDesigns { get; set; }
    internal virtual ICollection<ClientEntry> Clients { get; set; }
}