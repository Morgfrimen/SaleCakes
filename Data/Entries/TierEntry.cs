namespace Data.Entries;

internal class TierEntry
{
    internal TierEntry()
    {
        CakeDesigns = new HashSet<CakeDesign>();
    }

    internal Guid Id { get; set; }
    internal Guid? Stuffing { get; set; }
    internal Guid? Decor { get; set; }
    internal Guid? Shortcake { get; set; }

    internal virtual DecorEntry DecorEntry { get; set; }
    internal virtual ShortcakeEntry ShortcakeEntry { get; set; }
    internal virtual StuffingEntry StuffingEntry { get; set; }
    internal virtual ICollection<CakeDesign> CakeDesigns { get; set; }
}