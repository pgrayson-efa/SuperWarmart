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
        private OrderService CreateOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var orderService = new OrderService(userId);
            return orderService;
        }
        /// <summary>
        /// Create a new Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IHttpActionResult Post(OrderCreate order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOrderService();

            if (service.CreateOrder(order) != 1)
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Get all Orders from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            OrderService orderService = CreateOrderService();
            var orders = await orderService.GetOrder();
            return Ok(orders);
        }
        /// <summary>
        /// Get an Order by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(int id)
        {
            OrderService orderService = CreateOrderService();
            var orders = await orderService.GetOrderByOrderId(id);
            return Ok(orders);
        }
        /// <summary>
        /// Update an existing order in the database
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Delete an order from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


    }
}
