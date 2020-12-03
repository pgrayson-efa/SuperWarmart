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
        private InventoryItemService CreateInventoryItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var stateService = new InventoryItemService(userId);
            return stateService;
        }
        /// <summary>
        /// Create a new Inventory Item
        /// </summary>
        /// <param name="inventoryItem"></param>
        /// <returns></returns>
        public IHttpActionResult Post(InventoryItemCreate inventoryItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateInventoryItemService();

            if (!service.CreateInventoryItem(inventoryItem))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Get All Inventory Items in the database
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            InventoryItemService InventoryItemService = CreateInventoryItemService();
            var inventoryItems = InventoryItemService.GetInventoryItem();
            return Ok(inventoryItems);
        }
        /// <summary>
        /// Delete an Inventory Item from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
