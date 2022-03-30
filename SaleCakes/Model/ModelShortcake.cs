using System;

namespace SaleCakes.Model;

internal class ModelShortcake
{
    public ModelShortcake(Guid id, string name, string price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string Price { get; }
}