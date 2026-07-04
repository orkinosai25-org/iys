namespace Iys.Modules.Ai.Domain;

public sealed record AiCapabilityCatalog(
    string PrimaryProvider,
    IReadOnlyCollection<AiCapability> Capabilities,
    IReadOnlyCollection<string> IntegrationBacklog);
