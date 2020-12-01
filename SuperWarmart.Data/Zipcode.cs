using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    public class ZipCode
    {
        [Key]
        public int ZipCodeId { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string VerifiedZipCode { get; set; }
    }
}
