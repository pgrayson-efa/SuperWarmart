using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    [DataContract]
    public class OrderLineItem
    {
        [Key]
        public int OrderLineItemId { get; set; }

        [Required]
        [DataMember]
        public int OrderId { get; set; }

        [Required]
        [DataMember]
        public int InventoryItemId { get; set; }
        public virtual InventoryItem InventoryItem {get; set; }
        [DataMember]
        public int QuantityOrdered { get; set; }

    }
}
