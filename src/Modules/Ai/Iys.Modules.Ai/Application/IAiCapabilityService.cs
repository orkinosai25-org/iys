using Iys.Modules.Ai.Domain;

namespace Iys.Modules.Ai.Application;

public interface IAiCapabilityService
{
    AiCapabilityCatalog GetCapabilityCatalog();
}
