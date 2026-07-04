namespace Iys.Modules.Inventory.Domain;

public sealed record StockBalance(
    Guid ItemId,
    Guid WarehouseId,
    decimal OnHandQuantity,
    decimal ReservedQuantity,
    string Unit);
