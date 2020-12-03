using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Model
{
    public class CustomerUpdate
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string StreetAddress { get; set; }
        public int StateId { get; set; }
        public int ZipCodeId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
