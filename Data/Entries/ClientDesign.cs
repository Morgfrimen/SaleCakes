namespace Data.Entries;

internal class ClientDesign
{
    internal Guid Id { get; set; }
    internal Guid? ClientId { get; set; }
    internal Guid? OrderId { get; set; }

    internal virtual ClientEntry? Client { get; set; }
    internal virtual OrderClientEntry? Order { get; set; }
}