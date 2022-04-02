using System;

namespace SaleCakes.Model;

public class StuffingModel
{
    public StuffingModel(Guid id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; }
}