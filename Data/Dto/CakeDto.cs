namespace Data.Dto;

public record CakeDto
{
    public CakeDto(Guid id, decimal weight, IEnumerable<TiersDto> tiersId, string name) : this(weight, tiersId, name)
    {
        Id = id;
    }

    public CakeDto(decimal weight, IEnumerable<TiersDto> tiersId, string name)
    {
        Weight = weight;
        TiersId = tiersId;
        Name = name;
    }

    public Guid Id { get; }
    public decimal Weight { get; }
    public string Name { get; }
    public IEnumerable<TiersDto> TiersId { get; }
}