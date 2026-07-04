using Iys.SharedKernel;

namespace Iys.Modules.Catalog.Domain;

public sealed record Item(
    Guid Id,
    string Sku,
    string Name,
    string ItemType,
    string BaseUnit,
    string TrackingPolicy,
    int ReorderPoint,
    int TargetStockLevel,
    bool IsActive) : Entity(Id);
