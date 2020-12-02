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
    public class ZipCodeController : ApiController
    {
        private ZipCodeService CreateZipCodeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var zipCodeService = new ZipCodeService(userId);
            return zipCodeService;
        }
        /// <summary>
        /// Add a new Zip Code
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public IHttpActionResult Post(ZipCodeCreate zipCode)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateZipCodeService();

            if (!service.CreateZipCode(zipCode))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Get all Zip Codes from the database
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            ZipCodeService zipCodeService = CreateZipCodeService();
            var zipCodes = zipCodeService.GetZipCode();
            return Ok(zipCodes);
        }
        /// <summary>
        /// Delete an existing Zip Code from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            ZipCodeService zipCodeService = CreateZipCodeService();
            var zipCodes = zipCodeService.DeleteZipCodeByZipCodeId(id);
            if (zipCodes == true)
            {
                return Ok(zipCodes);
            }
            return InternalServerError();
        }
    }
}
