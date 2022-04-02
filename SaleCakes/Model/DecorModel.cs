using System;

namespace SaleCakes.Model;

internal class DecorModel
{
    public DecorModel(Guid id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; }
}