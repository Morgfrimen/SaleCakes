namespace Data.Legacy.Dto;

public record TiersDto
{
    public TiersDto(Guid id, Guid stuffingId, Guid decorId, Guid shortcakeId)
        : this(stuffingId, decorId, shortcakeId)
    {
        Id = id;
    }


    public TiersDto(Guid stuffingId, Guid decorId, Guid shortcakeId)
    {
        StuffingId = stuffingId;
        DecorId = decorId;
        ShortcakeId = shortcakeId;
    }

    public Guid Id { get; }
    public Guid StuffingId { get; }
    public Guid DecorId { get; }
    public Guid ShortcakeId { get; }
}