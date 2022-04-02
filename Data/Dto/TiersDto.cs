namespace Data.Dto;

public record TiersDto
{
    public TiersDto(Guid id, StuffingDto stuffingId, DecorDto decorId, ShortcakeDto shortcakeId)
        : this(stuffingId, decorId, shortcakeId)
    {
        Id = id;
    }

    public TiersDto(StuffingDto stuffingId, DecorDto decorId, ShortcakeDto shortcakeId)
    {
        StuffingId = stuffingId;
        DecorId = decorId;
        ShortcakeId = shortcakeId;
    }

    public Guid Id { get; }
    public StuffingDto StuffingId { get; }
    public DecorDto DecorId { get; }
    public ShortcakeDto ShortcakeId { get; }
}