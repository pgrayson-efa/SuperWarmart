using Microsoft.AspNet.Identity;
using SuperWarmart.Model;
using SuperWarmart.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SuperWarmart.WebAPI.Controllers
{
    public class OrderLineItemController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            OrderLineItemService orderLineItemService = CreateOrderLineItemService();
            var orderLineItems = await orderLineItemService.GetOrderLineItem();
            return Ok(orderLineItems);
        }
        public async Task<IHttpActionResult> Get(int id)
        {
            OrderLineItemService orderLineItemService = CreateOrderLineItemService();
            var orderLineItems = await orderLineItemService.GetOrderLineItemById(id);
            return Ok(orderLineItems);
        }
        public IHttpActionResult Post(OrderLineItemCreate orderLineItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOrderLineItemService();

            if (!service.CreateOrderLineItem(orderLineItem))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            OrderLineItemService orderLineItemService = CreateOrderLineItemService();
            var orderLineItems = orderLineItemService.DeleteOrderLineItemByOrderLineItemId(id);
            if (orderLineItems == true)
            {
                return Ok(orderLineItems);
            }
            return InternalServerError();
        }

        private OrderLineItemService CreateOrderLineItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var orderLineItemService = new OrderLineItemService(userId);
            return orderLineItemService;
        }
    }
}
