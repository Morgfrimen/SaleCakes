namespace Data.Entries;

public class ShortcakeEntry
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