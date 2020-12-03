using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Service
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity = new Customer()
            {
                OwnerId = _userId,
                CustomerId = model.CustomerId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CompanyName = model.CompanyName,
                StreetAddress = model.StreetAddress,
                StateId = model.StateId,
                ZipCodeId = model.ZipCodeId,
                PhoneNumber = model.PhoneNumber
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        // get all customers
        public IEnumerable<CustomerListItem> GetCustomer()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Customers
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    OwnerId = e.OwnerId,
                                    CustomerId = e.CustomerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    CompanyName = e.CompanyName,
                                    StreetAddress = e.StreetAddress,
                                    State = e.State,
                                    ZipCode = e.ZipCode,
                                    PhoneNumber = e.PhoneNumber,
                                    ShippingAddress = e.ShippingAddress
                                }
                        );

                return query.ToArray();
            }
        }

        // get customer by Id
       public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var model = ctx.Customers.Single(c => c.CustomerId == id);

                return
                    new CustomerDetail
                    {
                        OwnerId = model.OwnerId,
                        CustomerId = model.CustomerId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        CompanyName = model.CompanyName,
                        StreetAddress = model.StreetAddress,
                        State = model.State,
                        ZipCode = model.ZipCode,
                        PhoneNumber = model.PhoneNumber,
                        ShippingAddress = model.ShippingAddress
                    };
            }
        }
        
        //Get Customer by Name
        public CustomerDetail GetCustomerByName(string lastName, string firstName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var model = ctx.Customers.Single(c => (c.LastName == lastName && c.FirstName == firstName));

                return
                    new CustomerDetail
                    {
                        OwnerId = model.OwnerId,
                        CustomerId = model.CustomerId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        CompanyName = model.CompanyName,
                        StreetAddress = model.StreetAddress,
                        State = model.State,
                        ZipCode = model.ZipCode,
                        PhoneNumber = model.PhoneNumber,
                        ShippingAddress = model.ShippingAddress

                    };
            }
        }
        // Update Customer Info
        public bool UpdateCustomer(CustomerUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(c => c.CustomerId == model.CustomerId);

                entity.CustomerId = model.CustomerId;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.CompanyName = model.CompanyName;
                entity.StreetAddress = model.StreetAddress;
                entity.StateId = model.StateId;
                entity.ZipCodeId = model.ZipCodeId;
                entity.PhoneNumber = model.PhoneNumber;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
