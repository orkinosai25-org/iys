using Iys.SharedKernel;

namespace Iys.Modules.Purchasing.Domain;

public sealed record Supplier(
    Guid Id,
    string Code,
    string Name,
    string CountryCode,
    int LeadTimeDays,
    string DefaultCurrency,
    bool SupportsElectronicDocuments) : Entity(Id);
