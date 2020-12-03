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
        //Establish connection
        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var customerService = new CustomerService(userId);
            return customerService;
        }
        //Create new customer
        /// <summary>
        /// Create a New Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public IHttpActionResult Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerService();

            if (!service.CreateCustomer(customer))
                return InternalServerError();

            return Ok();
        }
        //Get all customers
        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            CustomerService customerService = CreateCustomerService();
            var customers = customerService.GetCustomer();
            return Ok(customers);
        }
        //Get customer by Id
        /// <summary>
        /// Get a Customer by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            CustomerService customerService = CreateCustomerService();
            var customers = customerService.GetCustomerById(id);
            return Ok(customers);
        }
        //Get customer by Name 
        /// <summary>
        /// Get customer by LastName/FirstName
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public IHttpActionResult Get(string lastName, string firstName)
        {
            CustomerService customerService = CreateCustomerService();
            var customers = customerService.GetCustomerByName(lastName, firstName);
            return Ok(customers);
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
    }
}
