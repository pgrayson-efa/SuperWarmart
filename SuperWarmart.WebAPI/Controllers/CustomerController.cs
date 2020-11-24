using Microsoft.AspNet.Identity;
using SuperWarmart.Data;
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
    public class CustomerController : ApiController
    {
        //Get all customers
        public IHttpActionResult Get()
        {
            CustomerService customerService = CreateCustomerService();
            var customers = customerService.GetCustomer();
            return Ok(customers);
        }
        //Get customer by Id
        public IHttpActionResult Get(int id)
        {
            CustomerService customerService = CreateCustomerService();
            var customers = customerService.GetCustomerById(id);
            return Ok(customers);
        }
        //Get customer by Name 
        public IHttpActionResult Get(string lastName, string firstName)
        {
            CustomerService customerService = CreateCustomerService();
            var customers = customerService.GetCustomerByName(lastName, firstName);
            return Ok(customers);
        }
        //Create new customer
        public IHttpActionResult Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerService();

            if (!service.CreateCustomer(customer))
                return InternalServerError();

            return Ok();
        }
        //Update customer by ID
        public IHttpActionResult Put(CustomerUpdate customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCustomerService();
            if (!service.UpdateCustomer(customer))
                return InternalServerError();
            return Ok();
        }
        //Establish connection
        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var customerService = new CustomerService(userId);
            return customerService;
        }
    }
}
