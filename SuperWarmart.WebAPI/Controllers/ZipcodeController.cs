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
        public IHttpActionResult Get()
        {
            ZipCodeService zipCodeService = CreateZipCodeService();
            var zipCodes = zipCodeService.GetZipCode();
            return Ok(zipCodes);
        }
        public IHttpActionResult Post(ZipCodeCreate zipCode)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateZipCodeService();

            if (!service.CreateZipCode(zipCode))
                return InternalServerError();

            return Ok();
        }
        private ZipCodeService CreateZipCodeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var zipCodeService = new ZipCodeService(userId);
            return zipCodeService;
        }
    }
}
