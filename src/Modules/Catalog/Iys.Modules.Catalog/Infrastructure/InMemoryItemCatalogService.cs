using Iys.Modules.Catalog.Application;
using Iys.Modules.Catalog.Domain;

namespace Iys.Modules.Catalog.Infrastructure;

internal sealed class InMemoryItemCatalogService : IItemCatalogService
{
    private static readonly IReadOnlyCollection<Item> Items =
    [
        new(
            Guid.Parse("4f00d48c-c7f5-46c4-a3d2-f23949934e3c"),
            "RM-STEEL-001",
            "Galvanized Steel Coil",
            "RawMaterial",
            "KG",
            "LotTracked",
            1_500,
            4_000,
            true),
        new(
            Guid.Parse("8d3d4663-ffea-4cae-a8ec-e96fd1ba7485"),
            "FG-PANEL-100",
            "Insulated Panel 100mm",
            "FinishedGood",
            "PCS",
            "SerialOptional",
            250,
            700,
            true)
    ];

    public Item? GetItem(Guid id) => Items.SingleOrDefault(item => item.Id == id);

    public IReadOnlyCollection<Item> GetItems() => Items;
}
