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

    public StuffingModel(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}