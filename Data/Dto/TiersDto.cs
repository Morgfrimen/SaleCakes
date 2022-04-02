namespace Data.Dto;

public record TiersDto
{
    public TiersDto(Guid id, StuffingDto stuffingId, DecorDto decorId, ShortcakeDto shortcakeId)
        : this(stuffingId, decorId, shortcakeId)
    {
        Id = id;
    }

    public TiersDto(StuffingDto stuffingDto, DecorDto decorDto, ShortcakeDto shortcakeDto)
    {
        StuffingDto = stuffingDto;
        DecorDto = decorDto;
        ShortcakeDto = shortcakeDto;
    }

    public Guid Id { get; }
    public StuffingDto StuffingDto { get; }
    public DecorDto DecorDto { get; }
    public ShortcakeDto ShortcakeDto { get; }
}