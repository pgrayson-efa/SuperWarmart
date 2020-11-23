using SuperWarmart.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Model
{
    public class CustomerListItem
    {
        public int CustomerId { get; set; }
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string HomeAddress { get; set; }
        public string HomeCity { get; set; }
        public int HomeStateId { get; set; }
        public int HomeZipcodeId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
