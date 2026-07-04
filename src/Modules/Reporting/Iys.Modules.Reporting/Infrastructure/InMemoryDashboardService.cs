using Iys.Modules.Reporting.Application;
using Iys.Modules.Reporting.Domain;

namespace Iys.Modules.Reporting.Infrastructure;

internal sealed class InMemoryDashboardService : IDashboardService
{
    public DashboardSnapshot GetSnapshot() =>
        new(
            DateTimeOffset.UtcNow,
            [
                new("inventory-accuracy", "Inventory Accuracy", "98.4%", "Up", "Healthy"),
                new("late-suppliers", "Late Suppliers", "2", "Stable", "Watch"),
                new("stock-risk", "Items Below Reorder Point", "7", "Down", "Attention")
            ],
            [
                "TODO: replace seed KPIs with warehouse, supplier, and production signals.",
                "TODO: wire reporting exports and Power BI embedding."
            ]);
}
