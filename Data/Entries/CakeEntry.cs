namespace Data.Entries;

internal class CakeEntry
{
    internal CakeEntry()
    {
        CakeDesigns = new HashSet<CakeDesign>();
        OrderClients = new HashSet<OrderClientEntry>();
    }

    internal Guid Id { get; set; }
    internal decimal Weight { get; set; }
    internal string Name { get; set; } = null!;

    internal virtual ICollection<CakeDesign> CakeDesigns { get; set; }
    internal virtual ICollection<OrderClientEntry> OrderClients { get; set; }
}