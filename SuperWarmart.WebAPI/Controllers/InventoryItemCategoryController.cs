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
    public class InventoryItemCategoryController : ApiController
    {
        private InventoryItemCategoryService CreateInventoryItemCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var stateService = new InventoryItemCategoryService(userId);
            return stateService;
        }
        /// <summary>
        /// Create a new Inventory Item Category
        /// </summary>
        /// <param name="inventoryItemCategory"></param>
        /// <returns></returns>
        public IHttpActionResult Post(InventoryItemCategoryCreate inventoryItemCategory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateInventoryItemCategoryService();

            if (!service.CreateInventoryItemCategory(inventoryItemCategory))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Get All Inventory Item Categories in the database
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            InventoryItemCategoryService inventoryItemCategoryService = CreateInventoryItemCategoryService();
            var inventoryItemCategories = inventoryItemCategoryService.GetInventoryItemCategory();
            return Ok(inventoryItemCategories);
        }
        /// <summary>
        /// Delete an Inventory Item Category from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            InventoryItemCategoryService inventoryItemCategoryService = CreateInventoryItemCategoryService();
            var inventoryItemCategories = inventoryItemCategoryService.DeleteInventoryItemCategoryById(id);
            if (inventoryItemCategories == true)
            {
                return Ok(inventoryItemCategories);
            }
            return InternalServerError();
        }
    }
}