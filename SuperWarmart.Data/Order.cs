using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public int StatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public string Notes { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double TotalCost { get; set; }
        [Required]
        public DateTime DateOfOrder { get; set; }
        public DateTime DateShipped { get; set; }

    }
}
