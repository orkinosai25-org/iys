using Iys.SharedKernel;

namespace Iys.Modules.Inventory.Domain;

public sealed record Warehouse(
    Guid Id,
    string Code,
    string Name,
    string Site,
    bool IsBondedCandidate,
    bool IsActive) : Entity(Id);
