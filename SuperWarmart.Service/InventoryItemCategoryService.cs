using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Service
{
    public class InventoryItemCategoryService
    {
        private readonly Guid _userId;

        public InventoryItemCategoryService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateInventoryItemCategory(InventoryItemCategoryCreate model)
        {
            var entity = new InventoryItemCategory()
            {
                InventoryItemCategoryId = model.InventoryItemCategoryId,
                CategoryName = model.CategoryName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.InventoryItemCategories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<InventoryItemCategoryListItem> GetInventoryItemCategory()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.InventoryItemCategories
                .Select(e =>
               new InventoryItemCategoryListItem
               {
                   InventoryItemCategoryId = e.InventoryItemCategoryId,
                   CategoryName = e.CategoryName
               }
                );
                return query.ToArray();
            }
        }
        public bool DeleteInventoryItemCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = (from o in ctx.InventoryItemCategories where o.InventoryItemCategoryId == id select o).SingleOrDefault();

                if (entity == null)
                {
                    return false;
                }
                ctx.InventoryItemCategories.Remove(entity);

                if (ctx.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}



