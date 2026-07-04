using Iys.SharedKernel;

namespace Iys.Modules.Purchasing.Domain;

public sealed record PurchaseOrder(
    Guid Id,
    string OrderNumber,
    Guid SupplierId,
    string Status,
    DateOnly ExpectedReceiptDate,
    Money TotalAmount);
