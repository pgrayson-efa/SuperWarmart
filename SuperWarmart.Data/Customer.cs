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
        public int CustomerId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public int StateId { get; set; }
        public virtual State State { get; set; }
        [Required]
        public int ZipCodeId { get; set; }
        public virtual ZipCode ZipCode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public virtual List<ShippingAddress> ShippingAddress { get; set; } = new List<ShippingAddress>();
    }
}
