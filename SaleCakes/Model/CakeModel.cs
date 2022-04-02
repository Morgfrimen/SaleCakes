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

    public uint Number { get; init; }

    public Guid Id { get; }
    public double Weight { get; }
    public Guid Tier { get; }
}