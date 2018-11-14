using System.Collections.Generic;
using System.Linq;
using Trainings.Interfaces;
using System.Data.Entity;
using Trainings.Entity;

namespace Trainings.Repository
{
    class TrainingRepository : IRepository<Training>
    {
        private Context.Context db;

        public TrainingRepository()
        { db = new Context.Context(); }

        public TrainingRepository(Context.Context context)
        {
            db = context;
        }

        public void Create(Training item)
        {
            db.Training.Add(item);
        }

        public void Create(IEnumerable<Training> items)
        {
            foreach (var item in items)
            {
                db.Training.Add(item);
            }
        }

        public void Delete(int id)
        {
            Training training = db.Training.Find(id);
            if (training != null)
            {
                db.Training.Remove(training);
            }
        }

        public IQueryable<Training> GetEntities()
        {
            return db.Training;
        }

        public Training GetEntity(int id)
        {
            return db.Training.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Training item)
        {
            db.Entry(item).State = EntityState.Modified;
        }        
    }
}
