using SuperWarmart.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Model
{
    public class ShippingAddressListItem
    {
        public int ShippingAddressId { get; set; }

        public int CustomerId { get; set; }

        public string LocationName { get; set; }
        public string StreetAddress { get; set; }
        public State State { get; set; }
        public ZipCode ZipCode { get; set; }
    }
}
