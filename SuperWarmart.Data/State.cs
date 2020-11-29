using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        public string StateName { get; set; }
        [Required]
        public string Abbr { get; set; }
    }
}
