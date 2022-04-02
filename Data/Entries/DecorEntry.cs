namespace Data.Entries;

internal class DecorEntry
{
    internal DecorEntry()
    {
        Tiers = new HashSet<TierEntry>();
    }

    internal Guid Id { get; set; }
    internal string Name { get; set; } = null!;
    internal decimal Price { get; set; }

    internal virtual ICollection<TierEntry> Tiers { get; set; }
}