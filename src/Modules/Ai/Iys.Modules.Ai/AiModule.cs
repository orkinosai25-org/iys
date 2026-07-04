using Iys.Modules.Ai.Application;
using Iys.Modules.Ai.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Iys.Modules.Ai;

public static class AiModule
{
    public static IServiceCollection AddAiModule(this IServiceCollection services)
    {
        services.AddSingleton<IAiCapabilityService, InMemoryAiCapabilityService>();
        return services;
    }

    public static IEndpointRouteBuilder MapAiModule(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/ai").WithTags("AI");

        group.MapGet("/capabilities", (IAiCapabilityService service) => Results.Ok(service.GetCapabilityCatalog()))
            .WithName("GetAiCapabilities");

        return endpoints;
    }
}
