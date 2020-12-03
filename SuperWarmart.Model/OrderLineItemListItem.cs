using SuperWarmart.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Model
{
    public class OrderLineItemListItem
    {
        public int OrderId { get; set; }
        public int OrderLineItemId { get; set; }
        //public int InventoryItemId { get; set; }
        public int QuantityOrdered { get; set; }
        public InventoryItemListItem InventoryItem { get; set; }
    }
}
