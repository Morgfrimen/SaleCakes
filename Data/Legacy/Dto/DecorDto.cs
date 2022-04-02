namespace Data.Legacy.Dto;

public record DecorDto
{
    public DecorDto(Guid id, string name, decimal price) : this(name, price)
    {
        Id = id;
    }

    public DecorDto(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; }
}