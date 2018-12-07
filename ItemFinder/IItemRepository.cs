using System.Collections.Generic;
using System.Threading.Tasks;
using ItemFinder.Models;

namespace ItemFinder
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItems();
        Task<int> PostNewItem(Item item);
        Task<Item> FindCloseItem(ItemLocation location);
    }
}