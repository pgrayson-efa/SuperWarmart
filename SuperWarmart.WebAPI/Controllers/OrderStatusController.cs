using Microsoft.AspNet.Identity;
using SuperWarmart.Model;
using SuperWarmart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperWarmart.WebAPI.Controllers
{
    [Authorize]
    public class OrderStatusController : ApiController
    {
        public IHttpActionResult Get()
        {
            OrderStatusService orderStatusService = CreateOrderStatusService();
            var orderStatus = orderStatusService.GetOrderStatus();
            return Ok(orderStatus);
        }
        public IHttpActionResult Post(OrderStatusCreate orderStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateOrderStatusService();

            if (!service.CreateOrderStatus(orderStatus))
                return InternalServerError();

            return Ok();
        }
        private OrderStatusService CreateOrderStatusService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var orderStatusService = new OrderStatusService(userId);
            return orderStatusService;
        }
        public IHttpActionResult Delete(int id)
        {
            OrderStatusService orderStatusService = CreateOrderStatusService();
            var orderStatuses = orderStatusService.DeleteOrderStatusById(id);
            if (orderStatuses == true)
            {
                return Ok(orderStatuses);
            }
            return InternalServerError();
        }
    }
}