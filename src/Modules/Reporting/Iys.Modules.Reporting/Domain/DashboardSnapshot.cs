namespace Iys.Modules.Reporting.Domain;

public sealed record DashboardSnapshot(
    DateTimeOffset GeneratedAtUtc,
    IReadOnlyCollection<DashboardMetric> Metrics,
    IReadOnlyCollection<string> AttentionItems);
