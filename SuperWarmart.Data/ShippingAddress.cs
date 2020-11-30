using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    public class ShippingAddress
    {
        [Key]
        public int ShippingAddressId { get; set; }


        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please Enter A Value.")]
        [MaxLength(50, ErrorMessage = "Value Must Be 50 Characters Or Less.")]
        public string LocationName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        public int ZipCodeId { get; set; }

    }
}
