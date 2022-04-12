using System;
using System.Collections.Generic;

namespace SaleCakes.Model;

public class CakeModel
{
    public CakeModel(Guid id, double weight, ICollection<TiersModel> tier)
    {
        Id = id;
        Weight = weight;
        Tier = tier;
    }

    public CakeModel(Guid id, decimal weight, ICollection<TiersModel> tier)
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
    public ICollection<TiersModel> Tier { get; set; }
}