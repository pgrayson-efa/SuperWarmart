using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    public class Zipcode
    {
        [Key]
        public int ZipcodeId { get; set; }

        [Required]
        public string VerifiedZipcode { get; set; }
    }
}
