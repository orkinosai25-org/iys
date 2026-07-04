namespace Iys.Modules.Reporting.Domain;

public sealed record DashboardMetric(
    string Code,
    string Label,
    string Value,
    string Trend,
    string Status);
