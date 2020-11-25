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
        private readonly Guid _userId;

        public ShippingAddressService(Guid userId)
        {
            _userId = userId;
        }

        //Create a new Shipping Address
        public async Task<bool> CreateShippingAddress(ShippingAddressCreate model)
        {
            var entity = new ShippingAddress()
            {
                ShippingAddressId = model.ShippingAddressId,
                CustomerId = model.CustomerId,
                LocationName = model.LocationName,
                StreetAddress = model.StreetAddress,
                City = model.City,
                StateId = model.StateId,
                ZipCodeId = model.ZipCodeId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ShippingAddresses.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        // Get all addresses
        public IEnumerable<ShippingAddressListItem> GetShippingAddresses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .ShippingAddresses
                    .Select(
                            a =>
                                new ShippingAddressListItem
                                {
                                    ShippingAddressId = a.ShippingAddressId,
                                    CustomerId = a.CustomerId,
                                    LocationName = a.LocationName,
                                    StreetAddress = a.StreetAddress,
                                    City = a.City,
                                    StateId = a.StateId,
                                    ZipCodeId = a.ZipCodeId
                                });
                return query.ToArray();
            }
        }

        // Get all addresses by Id
        public IEnumerable<ShippingAddressListItem> GetShippingAddressesByCustomer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .ShippingAddresses
                    .Where(c => c.CustomerId == id)
                    .Select(
                            a =>
                                new ShippingAddressListItem
                                {
                                    ShippingAddressId = a.ShippingAddressId,
                                    CustomerId = a.CustomerId,
                                    LocationName = a.LocationName,
                                    StreetAddress = a.StreetAddress,
                                    City = a.City,
                                    StateId = a.StateId,
                                    ZipCodeId = a.ZipCodeId
                                });
                return query.ToArray();
            }
        }

        public bool UpdateShippingAddress(int id, ShippingAddressUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ShippingAddresses
                    .Single(a => a.ShippingAddressId == id);
                
                entity.CustomerId = model.CustomerId;
                entity.LocationName = model.LocationName;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.StateId = model.StateId;
                entity.ZipCodeId = model.ZipCodeId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteShippingAddress(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var entity =
                //    ctx
                //    .ShippingAddresses
                //    .Single(s => s.ShippingAddressId == id);

                //ctx.ShippingAddresses.Remove(entity);

                //return ctx.SaveChanges() == 1;
                var entity = (from s in ctx.ShippingAddresses where s.ShippingAddressId == id select s).SingleOrDefault();
                if (entity == null)
                {
                    return false;
                }
                ctx.ShippingAddresses.Remove(entity);
                if (ctx.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
        }
    }


}
