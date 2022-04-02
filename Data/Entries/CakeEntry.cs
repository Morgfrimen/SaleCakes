namespace Data.Entries;

public class CakeEntry
{
    public CakeEntry()
    {
        OrderClients = new HashSet<OrderClientEntry>();
    }

    public Guid Id { get; set; }
    public decimal Weight { get; set; }
    public Guid Tiers { get; set; }

    public virtual TierEntry TiersEntryNavigation { get; set; } = null!;
    public virtual ICollection<OrderClientEntry> OrderClients { get; set; }
}