using Iys.Modules.Inventory.Application;
using Iys.Modules.Inventory.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Iys.Modules.Inventory;

public static class InventoryModule
{
    public static IServiceCollection AddInventoryModule(this IServiceCollection services)
    {
        services.AddSingleton<InMemoryInventoryService>();
        services.AddSingleton<IWarehouseService>(provider => provider.GetRequiredService<InMemoryInventoryService>());
        services.AddSingleton<IStockTraceabilityService>(provider => provider.GetRequiredService<InMemoryInventoryService>());
        return services;
    }

    public static IEndpointRouteBuilder MapInventoryModule(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/inventory").WithTags("Inventory");

        group.MapGet("/warehouses", (IWarehouseService service) => Results.Ok(service.GetWarehouses()))
            .WithName("GetWarehouses");

        group.MapGet("/stock-balances", (IWarehouseService service) => Results.Ok(service.GetStockBalances()))
            .WithName("GetStockBalances");

        group.MapGet("/stock-movements", (IStockTraceabilityService service) => Results.Ok(service.GetStockMovements()))
            .WithName("GetStockMovements");

        return endpoints;
    }
}
