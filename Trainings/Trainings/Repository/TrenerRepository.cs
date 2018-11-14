using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Trainings.Interfaces;
using Trainings.Entity;

namespace Trainings.Repository
{
    class TrenerRepository : IRepository<Trener>
    {
        private Context.Context db;

        public TrenerRepository()
        { db = new Context.Context(); }

        public TrenerRepository(Context.Context context)
        {
            db = context;
        }       

        public void Create(Trener item)
        {
            db.Trener.Add(item);
        }

        public void Create(IEnumerable<Trener> items)
        {
            foreach (var item in items)
            {
                db.Trener.Add(item);
            }
        }

        public void Delete(int id)
        {
            Trener trener = db.Trener.Find(id);
            if (trener != null)
            {
                db.Trener.Remove(trener);
            }
        }

        public IQueryable<Trener> GetEntities()
        {
            return db.Trener;
        }

        public Trener GetEntity(int id)
        {
            return db.Trener.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Trener item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

    }
}
