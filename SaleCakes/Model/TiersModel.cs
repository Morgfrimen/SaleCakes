using System;

namespace SaleCakes.Model;

public class TiersModel
{
    public Guid Id { get; set; }
    public StuffingModel StuffingModel { get; set; }
    public DecorModel DecorModel { get; set; }
    public ShortcakeModel ShortcakeModel { get; set; }
}