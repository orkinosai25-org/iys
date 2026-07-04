using Iys.Modules.Purchasing.Domain;

namespace Iys.Modules.Purchasing.Application;

public interface IPurchaseOrderService
{
    IReadOnlyCollection<PurchaseOrder> GetPurchaseOrders();
}
