using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Service
{
    public class ZipCodeService
    {
        private readonly Guid _userId;

        public ZipCodeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateZipCode(ZipCodeCreate model)
        {
            var entity = new ZipCode()
            {
                ZipCodeId = model.ZipCodeId,
                VerifiedZipCode = model.VerifiedZipCode
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ZipCodes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ZipCodeListItem> GetZipCode()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ZipCodes
                        .Select(
                            e =>
                                new ZipCodeListItem
                                {
                                    ZipCodeId = e.ZipCodeId,
                                    VerifiedZipCode = e.VerifiedZipCode
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
