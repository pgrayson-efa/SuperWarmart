using SuperWarmart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Model
{
    public class CustomerDetail
    {
        public int CustomerId { get; set; }
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string StreetAddress { get; set; }
        public ZipCode ZipCode { get; set; }
        public State State { get; set; }
        public string PhoneNumber { get; set; }
        public List<ShippingAddress> ShippingAddress { get; set; }
    }
}
