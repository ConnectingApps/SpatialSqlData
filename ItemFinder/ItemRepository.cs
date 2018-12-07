using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemFinder.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace ItemFinder
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemContext _context;

        public ItemRepository(ItemContext context)
        {
            _context = context;
        }

        public Task<List<Item>> GetAllItems()
        {
            return _context.ItemEntities.Select(a => new Item
            {
                Name = a.Name,
                Location = new ItemLocation
                {
                    X = a.Location.X,
                    Y = a.Location.Y
                }
            }).ToListAsync();
        }

        public Task<int> PostNewItem(Item item)
        {
            var toAdd = new ItemEntity
            {
                Name = item.Name,
                Location = new Point(item.Location.X, item.Location.Y)
                {
                    SRID = 4326
                }
            };
            _context.ItemEntities.Add(toAdd);
            return _context.SaveChangesAsync();
        }

        public async Task<Item> FindCloseItem(ItemLocation location)
        {
            var givenPoint = new Point(location.X, location.Y)
            {
                SRID = 4326
            };
            var nearestItem = await (from f in _context.ItemEntities.TagWith(@"This is my spatial query!")
                orderby f.Location.Distance(givenPoint)
                select f).FirstAsync();
            return new Item
            {
                Name = nearestItem.Name,
                Location = new ItemLocation
                {
                    X = nearestItem.Location.X,
                    Y = nearestItem.Location.Y,
                }
            };
        }
    }
}