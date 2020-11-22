using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string HomeAddress { get; set; }
        public string HomeCity { get; set; }
        [Required]
        public int HomeStateId { get; set; }
        public int HomeZipcodeId { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
