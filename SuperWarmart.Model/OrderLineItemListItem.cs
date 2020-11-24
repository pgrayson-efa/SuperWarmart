using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Model
{
    public class OrderLineItemListItem
    {
        public int OrderLineItemId { get; set; }
        public int OrderId { get; set; }
        public int InventoryItemId { get; set; }
        public int QuantityOrdered { get; set; }
    }
}
