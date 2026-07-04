using Iys.Modules.Inventory.Domain;

namespace Iys.Modules.Inventory.Application;

public interface IStockTraceabilityService
{
    IReadOnlyCollection<StockMovement> GetStockMovements();
}
