using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    public class Customer
    {
        [Key]
        [ForeignKey("Order")]
        public int CustomerId { get; set; }
        public Order Order { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }

        [Required]
        public int StateId { get; set; }
        public State State { get; set; }

        [Required]
        public int ZipCodeId { get; set; }
        public ZipCode ZipCode { get; set; }


        [Required]
        public string PhoneNumber { get; set; }


        public virtual List<ShippingAddress> ShippingAddresses { get; set; } = new List<ShippingAddress>();
    }
}
