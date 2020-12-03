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
        private OrderLineItemService CreateOrderLineItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var orderLineItemService = new OrderLineItemService(userId);
            return orderLineItemService;
        }
        /// <summary>
        /// Create an Order Line Item
        /// </summary>
        /// <param name="orderLineItem"></param>
        /// <returns></returns>
        public IHttpActionResult Post(OrderLineItemCreate orderLineItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOrderLineItemService();

            if (!service.CreateOrderLineItem(orderLineItem))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Get all Order Line Items
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            OrderLineItemService orderLineItemService = CreateOrderLineItemService();
            var orderLineItems = await orderLineItemService.GetOrderLineItem();
            return Ok(orderLineItems);
        }
        /// <summary>
        /// Get an Order Line item by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(int id)
        {
            OrderLineItemService orderLineItemService = CreateOrderLineItemService();
            var orderLineItems = await orderLineItemService.GetOrderLineItemById(id);
            return Ok(orderLineItems);
        }
        /// <summary>
        /// Delete an Order Line Item from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

    }
}
