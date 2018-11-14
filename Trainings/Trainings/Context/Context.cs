using System.Data.Entity;
using Trainings.Entity;

namespace Trainings.Context
{
    class Context : DbContext
    {
        public Context():base("name = SqlConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>()); 
        }
        
        public DbSet<Trener> Trener { get; set; }
        public DbSet<Sportsman> Sportsman { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<SportsmanEating> SportsmanEating { get; set; }
        public DbSet<SportsmanInfo> SportsmanInfo { get; set; }

        public static Context Create()
        {
            return new Context();
        }
    }
}
