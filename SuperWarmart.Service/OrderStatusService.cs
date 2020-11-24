using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Service
{
    public class OrderStatusService
    {
        private readonly Guid _userId;

        public OrderStatusService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateOrderStatus(OrderStatusCreate model)
        {
            var entity = new OrderStatus()
            {
                StatusId = model.StatusId,
                Status = model.Status
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.OrderStatuses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<OrderStatusListItem> GetOrderStatus()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.OrderStatuses
                    .Select(
                    e =>
                    new OrderStatusListItem
                    {
                        StatusId = e.StatusId,
                        Status = e.Status
                    }
                    );
                return query.ToArray();
            }
        }
    }
}
