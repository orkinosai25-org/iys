namespace Iys.Modules.Inventory.Domain;

public sealed record StockMovement(
    Guid Id,
    Guid ItemId,
    Guid WarehouseId,
    string MovementType,
    decimal Quantity,
    string Unit,
    string Reference,
    string TraceabilityKey,
    DateTimeOffset OccurredAtUtc);
