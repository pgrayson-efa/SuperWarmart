using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
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

        public IEnumerable<OrderLineItemListItem> GetOrderLineItem()
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
                                    InventoryItemId = e.InventoryItemId,
                                    QuantityOrdered = e.QuantityOrdered
                                }
                        );

                return query.ToArray();
            }
        }

        public bool DeleteOrderLineItemByOrderLineItemId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //
                // This doesn't return anything you can check if you don't find the OrderLineItemId
                //
                // var entity = ctx.Orders.Single(s => s.OrderId == id);

                //
                // Thing that works and returns null if the query doesn't return anything
                //
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
