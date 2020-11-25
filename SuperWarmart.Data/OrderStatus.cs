using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    public class OrderStatus
    {
        [Key]
        public int StatusId { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
