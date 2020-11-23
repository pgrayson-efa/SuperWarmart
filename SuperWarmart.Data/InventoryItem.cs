using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    public class InventoryItem
    {
        [Key]
        public int InventoryItemId { get; set; }
        [Required]
        public int UPC { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string StockNumber { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int QuantityInStock { get; set; }

        // public virtual TotalAverageRating { get; set; }
    }
}

