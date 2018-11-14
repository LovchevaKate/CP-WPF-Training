using System;
using Trainings.Interfaces;
using Trainings.Entity;
using Trainings.Repository;

namespace Trainings.Context
{
    class UnitofWork:IDisposable
    {
        private Context db = new Context();
        private IRepository<Trener> trenerRepository;
        private IRepository<Sportsman> sportsmanRepository;
        private IRepository<Training> trainingRepository;
        private IRepository<SportsmanEating> sportsmanEatingRepository;
        private IRepository<SportsmanInfo> sportsmanInfoRepository;
        
        public IRepository<Trener> TrenerRepository
        {
            get
            {
                return trenerRepository ?? (trenerRepository = new TrenerRepository(db));
            }
        }
        public IRepository<Sportsman> SportsmanRepository
        {
            get
            {
                return sportsmanRepository ?? (sportsmanRepository = new SportsmanRepository(db));
            }
        }
        public IRepository<Training> TrainingRepository
        {
            get
            {
                return trainingRepository ?? (trainingRepository = new TrainingRepository(db));
            }
        }
        public IRepository<SportsmanEating> SportsmanEatingRepository
        {
            get
            {
                return sportsmanEatingRepository ?? (sportsmanEatingRepository = new Sportsman_EatingRepository(db));
            }
        }
        public IRepository<SportsmanInfo> Sportsman_InfoRepository
        {
            get
            {
                return sportsmanInfoRepository ?? (sportsmanInfoRepository = new Sportsman_InfoRepository(db));
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposedValues = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValues)
                if (disposing)
                {
                    db.Dispose();
                }
            disposedValues = true;
        }

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }
    }
}
