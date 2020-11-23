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
    public class ZipcodeController : ApiController
    {
        public IHttpActionResult Get()
        {
            ZipcodeService zipcodeService = CreateZipcodeService();
            var zipcodes = zipcodeService.GetZipcode();
            return Ok(zipcodes);
        }
        public IHttpActionResult Post(ZipcodeCreate zipcode)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateZipcodeService();

            if (!service.CreateZipcode(zipcode))
                return InternalServerError();

            return Ok();
        }
        private ZipcodeService CreateZipcodeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var zipcodeService = new ZipcodeService(userId);
            return zipcodeService;
        }
    }
}
