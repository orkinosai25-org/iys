using Iys.Modules.Purchasing.Application;
using Iys.Modules.Purchasing.Domain;
using Iys.SharedKernel;

namespace Iys.Modules.Purchasing.Infrastructure;

internal sealed class InMemoryPurchasingService : ISupplierService, IPurchaseOrderService
{
    private static readonly IReadOnlyCollection<Supplier> Suppliers =
    [
        new(
            Guid.Parse("be1bcf37-0c90-4d6d-ad96-6043880879b9"),
            "SUP-DE-001",
            "Balkan Industrial Supply GmbH",
            "DE",
            14,
            "EUR",
            true),
        new(
            Guid.Parse("a3fd5020-ab35-42d7-b80a-cbb3e7f0b89d"),
            "SUP-TR-007",
            "Trakya Packaging Kimya",
            "TR",
            5,
            "TRY",
            true)
    ];

    private static readonly IReadOnlyCollection<PurchaseOrder> Orders =
    [
        new(
            Guid.Parse("c0d2a75e-0393-4be5-84de-d8fef015d44a"),
            "PO-2026-0004",
            Guid.Parse("be1bcf37-0c90-4d6d-ad96-6043880879b9"),
            "Planned",
            new DateOnly(2026, 7, 18),
            new Money(18_750m, "EUR")),
        new(
            Guid.Parse("0bdf8307-f0c5-447b-923d-a828c823ffbe"),
            "PO-2026-0011",
            Guid.Parse("a3fd5020-ab35-42d7-b80a-cbb3e7f0b89d"),
            "Released",
            new DateOnly(2026, 7, 9),
            new Money(245_000m, "TRY"))
    ];

    public IReadOnlyCollection<PurchaseOrder> GetPurchaseOrders() => Orders;

    public IReadOnlyCollection<Supplier> GetSuppliers() => Suppliers;
}
