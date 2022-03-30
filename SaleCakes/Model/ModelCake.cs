﻿using System;

namespace SaleCakes.Model;

internal class ModelCake
{
    public ModelCake(Guid id, double weight, Guid tier)
    {
        Id = id;
        Weight = weight;
        Tier = tier;
    }

    public Guid Id { get; }
    public double Weight { get; }
    public Guid Tier { get; }
}