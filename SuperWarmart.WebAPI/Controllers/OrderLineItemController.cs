﻿using Microsoft.AspNet.Identity;
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
    public class OrderLineItemController : ApiController
    {
        public IHttpActionResult Get()
        {
            OrderLineItemService orderLineItemService = CreateOrderLineItemService();
            var orderLineItems = orderLineItemService.GetOrderLineItem();
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
        private OrderLineItemService CreateOrderLineItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var orderLineItemService = new OrderLineItemService(userId);
            return orderLineItemService;
        }
    }
}
