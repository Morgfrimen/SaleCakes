using System;

namespace SaleCakes.Model;

public class DecorModel
{
    public DecorModel(Guid id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public DecorModel(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}