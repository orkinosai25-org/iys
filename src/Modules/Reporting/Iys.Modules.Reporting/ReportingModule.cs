using Iys.Modules.Reporting.Application;
using Iys.Modules.Reporting.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Iys.Modules.Reporting;

public static class ReportingModule
{
    public static IServiceCollection AddReportingModule(this IServiceCollection services)
    {
        services.AddSingleton<IDashboardService, InMemoryDashboardService>();
        return services;
    }

    public static IEndpointRouteBuilder MapReportingModule(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/reporting").WithTags("Reporting");

        group.MapGet("/dashboard", (IDashboardService service) => Results.Ok(service.GetSnapshot()))
            .WithName("GetDashboardSnapshot");

        return endpoints;
    }
}
