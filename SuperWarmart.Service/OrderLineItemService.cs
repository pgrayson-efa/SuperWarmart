using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Service
{
    public class OrderLineItemService
    {

        private readonly Guid _userId;

        public OrderLineItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOrderLineItem(OrderLineItemCreate model)
        {
            var entity = new OrderLineItem()
            {
                OrderLineItemId = model.OrderLineItemId,
                OrderId = model.OrderId,
                InventoryItemId = model.InventoryItemId,
                QuantityOrdered = model.QuantityOrdered
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.OrderLineItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public async  Task<IEnumerable<OrderLineItemListItem>> GetOrderLineItem()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.OrderLineItems
                        .Select(
                            e =>
                                new OrderLineItemListItem
                                {
                                    OrderLineItemId = e.OrderLineItemId,
                                    OrderId = e.OrderId,
                                    QuantityOrdered = e.QuantityOrdered,
                                    //InventoryItemId = e.InventoryItemId,
                                    //InventoryItem = e.InventoryItem,
                                    InventoryItem = new InventoryItemListItem()
                                    {
                                        InventoryItemId = e.InventoryItem.InventoryItemId,
                                        UPC = e.InventoryItem.UPC,
                                        StockNumber = e.InventoryItem.StockNumber,
                                        ItemName = e.InventoryItem.ItemName,
                                        Description = e.InventoryItem.Description,
                                        Price = e.InventoryItem.Price,
                                        QuantityInStock = e.InventoryItem.QuantityInStock,
                                        InventoryItemCategoryId = e.InventoryItem.InventoryItemCategory.InventoryItemCategoryId,
                                        InventoryItemCategoryName = e.InventoryItem.InventoryItemCategory.CategoryName
                                    },

                                }
                        );

                return await query.ToListAsync();
            }
        }

        public async Task<OrderLineItemDetail> GetOrderLineItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var model = await ctx.OrderLineItems.SingleAsync(c => c.OrderLineItemId == id);

                return
                    new OrderLineItemDetail
                    {
                        OrderLineItemId = model.OrderLineItemId,
                        OrderId = model.OrderId,
                        //InventoryItemId = e.InventoryItemId,
                        InventoryItem = model.InventoryItem,
                        QuantityOrdered = model.QuantityOrdered
                    };
            }
        }

        public bool DeleteOrderLineItemByOrderLineItemId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = (from o in ctx.OrderLineItems where o.OrderLineItemId == id select o).SingleOrDefault();

                if (entity == null)
                {
                    return false;
                }

                ctx.OrderLineItems.Remove(entity);

                if (ctx.SaveChanges() == 1)
                {
                    return true;
                }

                return false;

            }
        }
    }
}
