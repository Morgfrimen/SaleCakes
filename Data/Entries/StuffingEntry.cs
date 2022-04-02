namespace Data.Entries;

internal class StuffingEntry
{
    internal StuffingEntry()
    {
        Tiers = new HashSet<TierEntry>();
    }

    internal Guid Id { get; set; }
    internal string Name { get; set; } = null!;
    internal decimal Price { get; set; }

    internal virtual ICollection<TierEntry> Tiers { get; set; }
}