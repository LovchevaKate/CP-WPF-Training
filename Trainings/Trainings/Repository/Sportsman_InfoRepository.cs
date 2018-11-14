using System.Collections.Generic;
using System.Linq;
using Trainings.Interfaces;
using System.Data.Entity;
using Trainings.Entity;

namespace Trainings.Repository
{
    class Sportsman_InfoRepository : IRepository<SportsmanInfo>
    {
        private Context.Context db;

        public Sportsman_InfoRepository()
        { db = new Context.Context(); }

        public Sportsman_InfoRepository(Context.Context context)
        {
            db = context;
        }

        public void Create(SportsmanInfo item)
        {
            db.SportsmanInfo.Add(item);
        }

        public void Create(IEnumerable<SportsmanInfo> items)
        {
            foreach (var item in items)
            {
                db.SportsmanInfo.Add(item);
            }
        }

        public void Delete(int id)
        {
            SportsmanInfo sportsman_Info = db.SportsmanInfo.Find(id);
            if (sportsman_Info != null)
            {
                db.SportsmanInfo.Remove(sportsman_Info);
            }
        }

        public IQueryable<SportsmanInfo> GetEntities()
        {
            return db.SportsmanInfo;
        }

        public SportsmanInfo GetEntity(int id)
        {
            return db.SportsmanInfo.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(SportsmanInfo item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
