using SuperWarmart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Model
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public Guid OwnerId { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Notes { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double TotalCost { get; set; }
        public DateTime DateOfOrder { get; set; }
        public DateTime DateShipped { get; set; }
        public List<OrderLineItem> OrderLineItems { get; set; }
    }
}
