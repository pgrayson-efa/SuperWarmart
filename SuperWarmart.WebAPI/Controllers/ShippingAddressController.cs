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
    [Authorize]
    public class ShippingAddressController : ApiController
    {
        //Establish connection
        private ShippingAddressService CreateShippingAddressService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ShippingAddressService = new ShippingAddressService(userId);
            return ShippingAddressService;
        }
        // Create Shipping Address
        /// <summary>
        /// Create a new Shipping Address for a Customer
        /// </summary>
        /// <param name="shippingAddress"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Post(ShippingAddressCreate shippingAddress)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShippingAddressService();
            var result = await service.CreateShippingAddress(shippingAddress);

            if (result == false)
                return InternalServerError();

            return Ok();
        }
        // Get Shipping Address
        /// <summary>
        /// Get All Shipping Addresses for all Customers
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            ShippingAddressService shippingAddressService = CreateShippingAddressService();
            var shippingAddresses = shippingAddressService.GetShippingAddresses();
            return Ok(shippingAddresses);
        }
        // Get Shipping Address by Customer Id
        /// <summary>
        /// Get all Shipping Addresses associated with a Customer ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            ShippingAddressService shippingAddressService = CreateShippingAddressService();
            var shippingAddresses = shippingAddressService.GetShippingAddressesByCustomerId(id);
            return Ok(shippingAddresses);
        }
        // Update Shipping Address
        /// <summary>
        /// Update an existing Shipping Address in the database 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shippingAddress"></param>
        /// <returns></returns>
        public IHttpActionResult Put([FromUri] int id, [FromBody] ShippingAddressUpdate shippingAddress)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateShippingAddressService();
            if (!service.UpdateShippingAddress(id, shippingAddress))
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Delete a Shipping Address from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult DeleteShippingAddress(int id)
        {
            ShippingAddressService service = CreateShippingAddressService();

            var shippingAddresses = service.DeleteShippingAddress(id);

            if (shippingAddresses == true)
            {
                return Ok(shippingAddresses);
            }
            return InternalServerError();
        }


    }
}
