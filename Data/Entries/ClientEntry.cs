namespace Data.Entries;

internal class ClientEntry
{
    internal ClientEntry()
    {
        ClientDesigns = new HashSet<ClientDesign>();
    }

    internal Guid Id { get; set; }
    internal string ClientName { get; set; } = null!;
    internal string ClientSurname { get; set; } = null!;
    internal string ClientPatronymic { get; set; }
    internal string ClientPhone { get; set; }
    internal string ClientEmail { get; set; }
    internal Guid? ClientOrders { get; set; }

    internal virtual OrderClientEntry ClientOrdersNavigation { get; set; }
    internal virtual ICollection<ClientDesign> ClientDesigns { get; set; }
}