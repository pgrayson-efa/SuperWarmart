using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string VerifiedZipCode { get; set; }
    }
}
