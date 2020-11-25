
using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Service
{
    public class InventoryItemService
    {
        private readonly Guid _userId;

        public InventoryItemService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateInventoryItem(InventoryItemCreate model)
        {
            var entity = new InventoryItem()
            {
                InventoryItemId = model.InventoryItemId,
                UPC = model.UPC,
                CategoryId = model.CategoryId,
                StockNumber = model.StockNumber,
                ItemName = model.ItemName,
                Description = model.Description,
                Price = model.Price,
                QuantityInStock = model.QuantityInStock
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.InventoryItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<InventoryItemListItem> GetInventoryItem()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.InventoryItems
                    .Select(
                    e =>
                    new InventoryItemListItem
                    {
                        InventoryItemId = e.InventoryItemId,
                        UPC = e.UPC,
                        CategoryId = e.CategoryId,
                        StockNumber = e.StockNumber,
                        ItemName = e.ItemName,
                        Description = e.Description,
                        Price = e.Price,
                        QuantityInStock = e.QuantityInStock
                    }
                    );

                return query.ToArray();
            }
        }

        public bool DeleteInventoryItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = (from o in ctx.InventoryItems where o.InventoryItemId == id select o).SingleOrDefault();

                if (entity == null)
                {
                    return false;
                }
                ctx.InventoryItems.Remove(entity);

                if (ctx.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
