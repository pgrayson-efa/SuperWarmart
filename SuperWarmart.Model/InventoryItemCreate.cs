using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Model
{
    public class InventoryItemCreate
    {
        public int InventoryItemId { get; set; }
        public string UPC { get; set; }
        public int CategoryId { get; set; }
        public string StockNumber { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int QuantityInStock { get; set; }
    }
}
