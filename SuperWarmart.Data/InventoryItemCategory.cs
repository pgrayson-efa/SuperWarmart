using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    public class InventoryItemCategory
    {
        [Key]
        public int InventoryItemCategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
