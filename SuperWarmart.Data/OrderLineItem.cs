using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    public class OrderLineItem
    {
        [Key]
        public int OrderLineItemId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int InventoryItemId { get; set; }
        //public virtual InventoryItem InventoryItem {get; set; }
        public int QuantityOrdered { get; set; }

    }
}
