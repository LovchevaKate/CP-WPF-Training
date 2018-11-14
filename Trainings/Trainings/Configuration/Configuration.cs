using System.Data.Entity.Migrations;

namespace Trainings.Context
{
    class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Training.Context";
            //строка отличающая переносы, которые принадлежат этой конфигурации, от переносов др конф-ий, исп. одну и ту же бд
        }
        protected override void Seed(Context context)  {  }
        //метод, кот. запуск. после обновления.. для начальной инициализации
    }
}
