using Iys.Modules.Purchasing.Domain;

namespace Iys.Modules.Purchasing.Application;

public interface ISupplierService
{
    IReadOnlyCollection<Supplier> GetSuppliers();
}
