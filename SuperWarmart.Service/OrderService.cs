using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SuperWarmart.Service
{
    public class OrderService : ApiController
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
                OrderStatusId = model.OrderStatusId,
                Notes = model.Notes,
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
                        .Select(
                            e =>
                                new OrderListItem
                                {
                                    OwnerId = _userId,
                                    OrderId = e.OrderId,
                                    CustomerId = e.CustomerId,
                                    OrderStatusId = e.OrderStatusId,
                                    Notes = e.Notes,
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


        public bool DeleteOrderByOrderId(int id)
        { 
            using (var ctx = new ApplicationDbContext())
            {
                //
                // This doesn't return anything you can check if it doesn't find the id to delete
                //
                // var entity = ctx.Orders.Single(s => s.OrderId == id);

                //
                // Thing that works and returns null if the query doesn't return anything
                //
                var entity = (from o in ctx.Orders where o.OrderId == id select o).SingleOrDefault();

                if (entity == null)
                {
                    return false;
                }

                ctx.Orders.Remove(entity);

                if (ctx.SaveChanges() == 1)
                {
                    return true;
                }

                return false;

            }
        }
    }
}
