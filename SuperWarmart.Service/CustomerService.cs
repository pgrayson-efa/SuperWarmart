using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
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
                HomeAddress = model.HomeAddress,
                HomeCity = model.HomeCity,
                HomeStateId = model.HomeStateId,
                HomeZipcodeId = model.HomeZipcodeId,
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
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    OwnerId = _userId,
                                    CustomerId = e.CustomerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    CompanyName = e.CompanyName,
                                    HomeAddress = e.HomeAddress,
                                    HomeCity = e.HomeCity,
                                    HomeStateId = e.HomeStateId,
                                    HomeZipcodeId = e.HomeZipcodeId,
                                    PhoneNumber = e.PhoneNumber
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
                        HomeAddress = model.HomeAddress,
                        HomeCity = model.HomeCity,
                        HomeStateId = model.HomeStateId,
                        HomeZipcodeId = model.HomeZipcodeId,
                        PhoneNumber = model.PhoneNumber
                    };
            }
        }
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
                        HomeAddress = model.HomeAddress,
                        HomeCity = model.HomeCity,
                        HomeStateId = model.HomeStateId,
                        HomeZipcodeId = model.HomeZipcodeId,
                        PhoneNumber = model.PhoneNumber
                    };
            }
        }
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
                entity.HomeAddress = model.HomeAddress;
                entity.HomeCity = model.HomeCity;
                entity.HomeStateId = model.HomeStateId;
                entity.HomeZipcodeId = model.HomeZipcodeId;
                entity.PhoneNumber = model.PhoneNumber;

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
