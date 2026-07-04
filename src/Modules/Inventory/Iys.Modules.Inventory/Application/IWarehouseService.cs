using Iys.Modules.Inventory.Domain;

namespace Iys.Modules.Inventory.Application;

public interface IWarehouseService
{
    IReadOnlyCollection<Warehouse> GetWarehouses();
    IReadOnlyCollection<StockBalance> GetStockBalances();
}
