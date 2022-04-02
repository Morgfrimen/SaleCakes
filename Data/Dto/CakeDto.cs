namespace Data.Legacy.Dto;

public record CakeDto
{
    public CakeDto(Guid id, decimal weight, IEnumerable<TiersDto> tiersId) : this(weight, tiersId)
    {
        Id = id;
    }

    public CakeDto(decimal weight, IEnumerable<TiersDto> tiersId)
    {
        Weight = weight;
        TiersId = tiersId;
    }

    public Guid Id { get; }
    public decimal Weight { get; }
    public IEnumerable<TiersDto> TiersId { get; }
}