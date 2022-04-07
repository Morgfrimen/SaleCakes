using System;

namespace SaleCakes.Model;

public class CakeModel
{
    public CakeModel(Guid id, double weight, Guid tier)
    {
        Id = id;
        Weight = weight;
        Tier = tier;
    }

    public CakeModel(Guid id, decimal weight, Guid tier)
    {
        Id = id;
        Weight = Convert.ToDouble(weight);
        Tier = tier;
    }

    public CakeModel()
    {
    }

    public uint Number { get; init; }

    public Guid Id { get; set; }
    public double Weight { get; set; }
    public string Title { get; set; }
    public Guid Tier { get; set; }
}