﻿using SuperWarmart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Model
{
    public class InventoryItemListItem
    {
        public int InventoryItemId { get; set; }

        public string UPC { get; set; }

        public int InventoryItemCategoryId { get; set; }
        public string InventoryItemCategoryName { get; set; }
        //public virtual InventoryItemCategory InventoryItemCategory { get; set; }

        public string StockNumber { get; set; }

        public string ItemName { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int QuantityInStock { get; set; }
    }
}
