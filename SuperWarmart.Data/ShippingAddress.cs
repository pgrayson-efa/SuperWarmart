using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    [DataContract]

    public class ShippingAddress
    {
        [Key]
        [DataMember]
        public int ShippingAddressId { get; set; }

        //[ForeignKey(nameof(Customer))]
        [DataMember]
        public int CustomerId { get; set; }
        //public virtual Customer Customer { get; set; }

        [Required]
        [DataMember]
        [MinLength(1, ErrorMessage = "Please Enter A Value.")]
        [MaxLength(50, ErrorMessage = "Value Must Be 50 Characters Or Less.")]
        public string LocationName { get; set; }
        [Required]
        [DataMember]
        public string StreetAddress { get; set; }

        [Required]
        [DataMember]
        public int StateId { get; set; }
        public virtual State State { get; set; }

        [Required]
        [DataMember]
        public int ZipCodeId { get; set; }
        public virtual ZipCode ZipCode { get; set; }

    }
}
