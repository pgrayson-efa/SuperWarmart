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
        public IHttpActionResult Get()
        {
            ShippingAddressService shippingAddressService = CreateShippingAddressService();
            var shippingAddresses = shippingAddressService.GetShippingAddresses();
            return Ok(shippingAddresses);
        }
        // Get Shipping Address by Customer Id
        public IHttpActionResult Get(int id)
        {
            ShippingAddressService shippingAddressService = CreateShippingAddressService();
            var shippingAddresses = shippingAddressService.GetShippingAddressesByCustomer(id);
            return Ok(shippingAddresses);
        }
        // Update Shipping Address
        public IHttpActionResult Put([FromUri] int id, [FromBody] ShippingAddressUpdate shippingAddress)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateShippingAddressService();
            if (!service.UpdateShippingAddress(id, shippingAddress))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult DeleteShippingAddress(int id)
        {
            var service = CreateShippingAddressService();

            var result = service.DeleteShippingAddress(id);

            if (!service.DeleteShippingAddress(id))
                return InternalServerError();

            return Ok();

        }


    }
}
