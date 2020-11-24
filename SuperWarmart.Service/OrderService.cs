using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Service
{
    public class OrderService
    {
        private readonly Guid _userId;

        public OrderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOrder(OrderCreate model)
        {
            var entity = new Order()
            {
                OwnerId = _userId,
                OrderId = model.OrderId,
                CustomerId = model.CustomerId,
                OrderStatus = model.OrderStatus,
                OrderNote = model.OrderNote,
                SubTotal = model.SubTotal,
                Tax = model.Tax,
                TotalCost = model.TotalCost,
                DateOfOrder = model.DateOfOrder,
                DateShipped = model.DateShipped

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OrderListItem> GetOrder()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Orders
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new OrderListItem
                                {
                                    OwnerId = _userId,
                                    OrderId = e.OrderId,
                                    CustomerId = e.CustomerId,
                                    OrderStatus = e.OrderStatus,
                                    OrderNote = e.OrderNote,
                                    SubTotal = e.SubTotal,
                                    Tax = e.Tax,
                                    TotalCost = e.TotalCost,
                                    DateOfOrder = e.DateOfOrder,
                                    DateShipped = e.DateShipped
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
