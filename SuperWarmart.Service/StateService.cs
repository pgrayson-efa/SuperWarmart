using SuperWarmart.Data;
using SuperWarmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Service
{
    public class StateService
    {
        private readonly Guid _userId;

        public StateService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateState(StateCreate model)
        {
            var entity = new State()
            {
                StateId = model.StateId,
                StateName = model.StateName,
                Abbr = model.Abbr
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.States.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<StateListItem> GetState()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.States
                    .Select(
                    e =>
                    new StateListItem
                    {
                        StateId = e.StateId,
                        StateName = e.StateName,
                        Abbr = e.Abbr
                    }
                    );

                return query.ToArray();
            }
        }
        public bool DeleteStateById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = (from o in ctx.States where o.StateId == id select o).SingleOrDefault();

                if (entity == null)
                {
                    return false;
                }
                ctx.States.Remove(entity);

                if (ctx.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}

