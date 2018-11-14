using System.Collections.Generic;
using System.Linq;
using Trainings.Interfaces;
using System.Data.Entity;
using Trainings.Entity;

namespace Trainings.Repository
{
    class SportsmanRepository : IRepository<Sportsman>
    {        
        private Context.Context db;

        public SportsmanRepository()
        { db = new Context.Context(); }

        public SportsmanRepository(Context.Context context)
        {
            db = context;
        }

        public void Create(Sportsman item)
        {
            db.Sportsman.Add(item);
        }

        public void Create(IEnumerable<Sportsman> items)
        {
            foreach (var item in items)
            {
                db.Sportsman.Add(item);
            }
        }

        public void Delete(int id)
        {
            Sportsman sportsman = db.Sportsman.Find(id);
            if (sportsman != null)
            {
                db.Sportsman.Remove(sportsman);
            }
        }

        public IQueryable<Sportsman> GetEntities()
        {
            return db.Sportsman.Include("Info");
        }

        public Sportsman GetEntity(int id)
        {
            return db.Sportsman.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Sportsman item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
