namespace Data.Entries;

internal class CakeDesign
{
    internal Guid Id { get; set; }
    internal Guid? CakeId { get; set; }
    internal Guid? TierId { get; set; }

    internal virtual CakeEntry? Cake { get; set; }
    internal virtual TierEntry? Tier { get; set; }
}