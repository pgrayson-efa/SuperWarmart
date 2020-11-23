using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Service
{
    public class ZipcodeService
    {
        private readonly Guid _userId;

        public ZipcodeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateZipcode(ZipcodeCreate model)
        {
            var entity = new Zipcode()
            {
                ZipcodeId = model.ZipcodeId,
                VerifiedZipcode = model.VerifiedZipcode
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Zipcodes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ZipcodeListItem> GetZipcode()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Zipcodes
                        .Select(
                            e =>
                                new ZipcodeListItem
                                {
                                    ZipcodeId = e.ZipcodeId,
                                    VerifiedZipcode = e.VerifiedZipcode
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
