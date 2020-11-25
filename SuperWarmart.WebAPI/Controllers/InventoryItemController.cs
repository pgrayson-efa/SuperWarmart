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
    public class InventoryItemController : ApiController
    {
        public IHttpActionResult Get()
        {
            InventoryItemService inventoryItemService = CreateInventoryItemService();
            var inventoryItems = inventoryItemService.GetInventoryItem();
            return Ok(inventoryItems);
        }
        public IHttpActionResult Post(InventoryItemCreate inventoryItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateInventoryItemService();

            if (!service.CreateInventoryItem(inventoryItem))
                return InternalServerError();

            return Ok();
        }
        private InventoryItemService CreateInventoryItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var stateService = new InventoryItemService(userId);
            return stateService;
        }
        public IHttpActionResult Delete(int id)
        {
            InventoryItemService inventoryItemService = CreateInventoryItemService();
            var inventoryItems = inventoryItemService.DeleteInventoryItemById(id);
            if (inventoryItems == true)
            {
                return Ok(inventoryItems);
            }
            return InternalServerError();
        }
    }
}
