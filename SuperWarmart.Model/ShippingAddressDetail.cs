using SuperWarmart.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Model
{
    public class ShippingAddressDetail
    {
        [Key]
        public int ShippingAddressId { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Need to enter something.")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters.")]

        public string LocationName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public int ZipcodeId { get; set; }
    }
}
