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

    public class ZipCode
    {
        [Key]
        public int ZipCodeId { get; set; }

        [Required]
        [DataMember]
        public int StateId { get; set; }
        [DataMember]
        [Required]
        public string City { get; set; }

        [Required]
        [DataMember]
        public string VerifiedZipCode { get; set; }
    }
}
