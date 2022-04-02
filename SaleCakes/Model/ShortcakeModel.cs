using System;

namespace SaleCakes.Model;

internal class ShortcakeModel
{
    public ShortcakeModel(Guid id, string name, string price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string Price { get; }
}