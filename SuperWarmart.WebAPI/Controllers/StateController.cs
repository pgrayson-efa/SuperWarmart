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
    public class StateController : ApiController
    {
        public IHttpActionResult Get()
        {
            StateService stateService = CreateStateService();
            var states = stateService.GetState();
            return Ok(states);
        }
        public IHttpActionResult Post(StateCreate state)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStateService();

            if (!service.CreateState(state))
                return InternalServerError();

            return Ok();
        }
        private StateService CreateStateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var stateService = new StateService(userId);
            return stateService;
        }
        public IHttpActionResult Delete(int id)
        {
            StateService stateService = CreateStateService();
            var states = stateService.DeleteStateById(id);
            if (states == true)
            {
                return Ok(states);
            }
            return InternalServerError();
        }
    }
}