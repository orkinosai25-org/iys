namespace Iys.Modules.Ai.Domain;

public sealed record AiCapability(
    string Code,
    string Name,
    string Purpose,
    string EnablementStatus,
    IReadOnlyCollection<string> Dependencies);
