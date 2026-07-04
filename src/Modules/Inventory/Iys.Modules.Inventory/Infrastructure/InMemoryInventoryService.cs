using Iys.Modules.Inventory.Application;
using Iys.Modules.Inventory.Domain;

namespace Iys.Modules.Inventory.Infrastructure;

internal sealed class InMemoryInventoryService : IWarehouseService, IStockTraceabilityService
{
    private static readonly IReadOnlyCollection<Warehouse> Warehouses =
    [
        new(
            Guid.Parse("79a2448f-c6b8-4c66-9151-1bc69b674145"),
            "MAIN",
            "Main Warehouse",
            "Ipsala OSB",
            false,
            true),
        new(
            Guid.Parse("57003da8-2031-4db7-b281-f12fd2e08f81"),
            "BOND",
            "Border Dispatch Buffer",
            "Ipsala Border Route",
            true,
            true)
    ];

    private static readonly IReadOnlyCollection<StockBalance> Balances =
    [
        new(
            Guid.Parse("4f00d48c-c7f5-46c4-a3d2-f23949934e3c"),
            Guid.Parse("79a2448f-c6b8-4c66-9151-1bc69b674145"),
            2_750,
            320,
            "KG"),
        new(
            Guid.Parse("8d3d4663-ffea-4cae-a8ec-e96fd1ba7485"),
            Guid.Parse("57003da8-2031-4db7-b281-f12fd2e08f81"),
            410,
            75,
            "PCS")
    ];

    private static readonly IReadOnlyCollection<StockMovement> Movements =
    [
        new(
            Guid.Parse("3df50be5-6d29-44a6-a5b1-f15590b04844"),
            Guid.Parse("4f00d48c-c7f5-46c4-a3d2-f23949934e3c"),
            Guid.Parse("79a2448f-c6b8-4c66-9151-1bc69b674145"),
            "GoodsReceipt",
            1_200,
            "KG",
            "GRN-2026-0001",
            "LOT-STEEL-2026-07-A",
            DateTimeOffset.Parse("2026-07-01T08:30:00Z")),
        new(
            Guid.Parse("0f48c45c-d91f-4541-83b7-6c1c1310d230"),
            Guid.Parse("8d3d4663-ffea-4cae-a8ec-e96fd1ba7485"),
            Guid.Parse("57003da8-2031-4db7-b281-f12fd2e08f81"),
            "ShipmentAllocation",
            -60,
            "PCS",
            "SO-2026-0152",
            "SERIAL-BLOCK-EXPORT-01",
            DateTimeOffset.Parse("2026-07-03T15:45:00Z"))
    ];

    public IReadOnlyCollection<StockBalance> GetStockBalances() => Balances;

    public IReadOnlyCollection<StockMovement> GetStockMovements() => Movements;

    public IReadOnlyCollection<Warehouse> GetWarehouses() => Warehouses;
}
