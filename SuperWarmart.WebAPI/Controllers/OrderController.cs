using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using SuperWarmart.Model;
using SuperWarmart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace SuperWarmart.WebAPI.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            OrderService orderService = CreateOrderService();
            var orders = await orderService.GetOrder();
            return Ok(orders);
        }

        public IHttpActionResult Get(int id)
        {
            OrderService orderService = CreateOrderService();
            var orders = orderService.GetOrderByOrderId(id);
            return Ok(orders);
        }

        public IHttpActionResult Delete(int id)
        {
            OrderService orderService = CreateOrderService();
            var orders = orderService.DeleteOrderByOrderId(id);
            if (orders == true)
            {
                return Ok(orders);
            }
            return InternalServerError();
        }

        public IHttpActionResult Put(OrderUpdate order)
        {
            if (ModelState.IsValid != true)
            {
                return BadRequest(ModelState);
            }
            var service = CreateOrderService();
            if (service.UpdateOrder(order) != true)
            {
                return InternalServerError();
            }
            return Ok();
        }

        public IHttpActionResult Post(OrderCreate order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOrderService();

            if (service.CreateOrder(order) != 1)
                return InternalServerError();

            return Ok();
        }

        private OrderService CreateOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var orderService = new OrderService(userId);
            return orderService;
        }
    }
}
