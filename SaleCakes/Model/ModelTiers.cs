using System;

namespace SaleCakes.Model;

public class ModelTiers
{
    public ModelTiers(Guid id, Guid stuffingId, Guid decorId, Guid shortcakeId)
    {
        Id = id;
        StuffingId = stuffingId;
        DecorId = decorId;
        ShortcakeId = shortcakeId;
    }

    public Guid Id { get; }
    public Guid StuffingId { get; }
    public Guid DecorId { get; }
    public Guid ShortcakeId { get; }
}