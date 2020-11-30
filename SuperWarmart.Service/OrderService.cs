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

        public int CreateOrder(OrderCreate model)
        {
            var entity = new Order()
            {
                OwnerId = _userId,
                OrderId = model.OrderId,
                CustomerId = model.CustomerId,
                StatusId = model.StatusId,
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

                if (ctx.SaveChanges() == 1)
                {
                    return 1;
                }
                return 0;
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
                                    StatusId = e.StatusId,
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

        public OrderDetail GetOrderByOrderId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var model = ctx.Orders.Single(c => c.OrderId == id);

                return
                    new OrderDetail
                    {
                        OwnerId = _userId,
                        OrderId = model.OrderId,
                        CustomerId = model.CustomerId,
                        StatusId = model.StatusId,
                        Notes = model.Notes,
                        SubTotal = model.SubTotal,
                        Tax = model.Tax,
                        TotalCost = model.TotalCost,
                        DateOfOrder = model.DateOfOrder,
                        DateShipped = model.DateShipped
                    };
            }
        }


        public bool DeleteOrderByOrderId(int id)
        { 
            using (var ctx = new ApplicationDbContext())
            {

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
        public bool UpdateOrder(OrderUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Orders.Single(o => o.OrderId == model.OrderId);

                entity.CustomerId = model.CustomerId;
                entity.StatusId = model.StatusId;
                entity.Notes = model.Notes;
                entity.SubTotal = model.SubTotal;
                entity.Tax = model.Tax;
                entity.TotalCost = model.TotalCost;
                entity.DateOfOrder = model.DateOfOrder;
                entity.DateShipped = model.DateShipped;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
