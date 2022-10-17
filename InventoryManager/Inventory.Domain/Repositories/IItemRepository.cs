using Inventory.Domain.Entities;
using Inventory.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetItemById(ItemId id);
        Task<IList<Item>> GetItems();
        Task AddItem(Item item);
        Task DelteItem(ItemId id);

    }
}
