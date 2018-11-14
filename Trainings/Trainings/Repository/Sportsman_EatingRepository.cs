using System.Collections.Generic;
using System.Linq;
using Trainings.Interfaces;
using System.Data.Entity;
using Trainings.Entity;

namespace Trainings.Repository
{
    class Sportsman_EatingRepository : IRepository<SportsmanEating>
    {
        private Context.Context db;

        public Sportsman_EatingRepository()
        { db = new Context.Context(); }

        public Sportsman_EatingRepository(Context.Context context)
        {
            db = context;
        }

        public void Create(SportsmanEating item)
        {
            db.SportsmanEating.Add(item);
        }

        public void Create(IEnumerable<SportsmanEating> items)
        {
            foreach (var item in items)
            {
                db.SportsmanEating.Add(item);
            }
        }

        public void Delete(int id)
        {
            SportsmanEating sportsman_Eating = db.SportsmanEating.Find(id);
            if (sportsman_Eating != null)
            {
                db.SportsmanEating.Remove(sportsman_Eating);
            }
        }

        public IQueryable<SportsmanEating> GetEntities()
        {
            return db.SportsmanEating;
        }

        public SportsmanEating GetEntity(int id)
        {
            return db.SportsmanEating.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(SportsmanEating item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
