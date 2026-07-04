using Iys.Modules.Purchasing.Application;
using Iys.Modules.Purchasing.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Iys.Modules.Purchasing;

public static class PurchasingModule
{
    public static IServiceCollection AddPurchasingModule(this IServiceCollection services)
    {
        services.AddSingleton<InMemoryPurchasingService>();
        services.AddSingleton<ISupplierService>(provider => provider.GetRequiredService<InMemoryPurchasingService>());
        services.AddSingleton<IPurchaseOrderService>(provider => provider.GetRequiredService<InMemoryPurchasingService>());
        return services;
    }

    public static IEndpointRouteBuilder MapPurchasingModule(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/purchasing").WithTags("Purchasing");

        group.MapGet("/suppliers", (ISupplierService service) => Results.Ok(service.GetSuppliers()))
            .WithName("GetSuppliers");

        group.MapGet("/purchase-orders", (IPurchaseOrderService service) => Results.Ok(service.GetPurchaseOrders()))
            .WithName("GetPurchaseOrders");

        return endpoints;
    }
}
