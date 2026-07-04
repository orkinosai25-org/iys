using Iys.Modules.Catalog.Domain;

namespace Iys.Modules.Catalog.Application;

public interface IItemCatalogService
{
    IReadOnlyCollection<Item> GetItems();
    Item? GetItem(Guid id);
}
