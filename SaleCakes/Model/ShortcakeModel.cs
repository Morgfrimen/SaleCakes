using System;

namespace SaleCakes.Model;

public class ShortcakeModel
{
    public ShortcakeModel(Guid id, string name, string price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public ShortcakeModel(string name, string price)
    {
        Name = name;
        Price = price;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Price { get; set; }
}