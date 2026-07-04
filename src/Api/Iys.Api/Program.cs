using Iys.Modules.Ai;
using Iys.Modules.Catalog;
using Iys.Modules.Inventory;
using Iys.Modules.Purchasing;
using Iys.Modules.Reporting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "IYS Platform API",
        Version = "v1",
        Description = "Initial scaffold for a modern AI-ready manufacturing and ERP-style platform."
    });
});

builder.Services
    .AddCatalogModule()
    .AddInventoryModule()
    .AddPurchasingModule()
    .AddReportingModule()
    .AddAiModule();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Ok(new
{
    Platform = "IYS Platform",
    Architecture = "Modular monolith",
    Focus = "Inventory, warehouse, purchasing, reporting, and AI-ready services",
    Documentation = "/swagger"
}))
.WithName("GetPlatformSummary")
.WithOpenApi();

app.MapGet("/health", () => Results.Ok(new
{
    Status = "Healthy",
    TimestampUtc = DateTimeOffset.UtcNow
}))
.WithName("GetHealth")
.WithOpenApi();

app.MapCatalogModule();
app.MapInventoryModule();
app.MapPurchasingModule();
app.MapReportingModule();
app.MapAiModule();

app.Run();

public partial class Program;
