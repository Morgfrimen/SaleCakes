namespace Data.Legacy.Dto;

public record StuffingDto
{
    public StuffingDto(Guid id, string name, decimal price) : this(name, price)
    {
        Id = id;
    }

    public StuffingDto(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; }
}