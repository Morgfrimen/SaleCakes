namespace Data.Entries;

public class TierEntry
{
    public TierEntry()
    {
        Cakes = new HashSet<CakeEntry>();
    }

    public Guid Id { get; set; }
    public Guid? Stuffing { get; set; }
    public Guid? Decor { get; set; }
    public Guid? Shortcake { get; set; }

    public virtual DecorEntry? DecorNavigation { get; set; }
    public virtual ShortcakeEntry? ShortcakeNavigation { get; set; }
    public virtual StuffingEntry? StuffingNavigation { get; set; }
    public virtual ICollection<CakeEntry> Cakes { get; set; }
}