using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Service
{
    public class ShippingAddressService
    {
        //Create Shipping Address
        public bool CreateShippingAddress(ShippingAddressCreate model)
        {
            var entity = new ShippingAddress()
            {
                ShippingAddressId = model.ShippingAddressId,
                CustomerId = model.CustomerId,
                LocationName = model.LocationName,
                StreetAddress = model.StreetAddress,
                City = model.City,
                StateId = model.StateId,
                ZipcodeId = model.ZipcodeId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ShippingAddresses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get all addresses by Id


    }
}
