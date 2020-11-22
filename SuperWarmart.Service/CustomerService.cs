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
    }
}
