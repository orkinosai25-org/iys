using Iys.Modules.Catalog.Application;
using Iys.Modules.Catalog.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Iys.Modules.Catalog;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services)
    {
        services.AddSingleton<IItemCatalogService, InMemoryItemCatalogService>();
        return services;
    }

    public static IEndpointRouteBuilder MapCatalogModule(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/catalog").WithTags("Catalog");

        group.MapGet("/items", (IItemCatalogService service) => Results.Ok(service.GetItems()))
            .WithName("GetCatalogItems");

        group.MapGet("/items/{id:guid}", (Guid id, IItemCatalogService service) =>
            service.GetItem(id) is { } item ? Results.Ok(item) : Results.NotFound())
            .WithName("GetCatalogItem");

        return endpoints;
    }
}
