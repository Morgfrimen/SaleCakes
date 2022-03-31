namespace Data.Dto;

public record CakeDto
{
    public CakeDto(Guid id, decimal weight, Guid tiersId) : this(weight, tiersId)
    {
        Id = id;
    }

    public CakeDto(decimal weight, Guid tiersId)
    {
        Weight = weight;
        TiersId = tiersId;
    }

    public Guid Id { get; }
    public decimal Weight { get; }
    public Guid TiersId { get; }
}